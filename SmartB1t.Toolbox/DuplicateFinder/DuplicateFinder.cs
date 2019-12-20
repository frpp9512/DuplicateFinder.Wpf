﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// A searcher for file duplications in a specific route.
    /// </summary>
    public class DuplicateFinder : IDuplicateFinder
    {
        #region Public Members

        /// <summary>
        /// The selected directory to find duplications in.
        /// </summary>
        public DirectoryInfo SelectedDirectory { get; set; }

        /// <summary>
        /// The selected way to perform the search.
        /// </summary>
        public DuplicationSearchWay SearchWay { get; set; } = DuplicationSearchWay.NameAndSizeComparison;

        /// <summary>
        /// The search progress caller provider.
        /// </summary>
        public Progress<DuplicationSearchProgressReport> ProgressReporter => (Progress<DuplicationSearchProgressReport>)Progress;

        /// <summary>
        /// The source for the cancellation requests.
        /// </summary>
        public CancellationTokenSource CancelTokenSource { get; }

        /// <summary>
        /// The current operation performed in the process.
        /// </summary>
        public DuplicateSearchStatus Status { get; set; }

        /// <summary>
        /// The current processing directory.
        /// </summary>
        public DirectoryInfo CurrentDirectory { get; private set; }

        /// <summary>
        /// The minimun size needed for replication analisys in bytes.
        /// </summary>
        public long MinimunSizeForAnalysis { get; set; } = 0;

        /// <summary>
        /// The search process completing percentage.
        /// </summary>
        public double SearchPercentage { get; set; }

        /// <summary>
        /// The directories mapped, where the search process will take place.
        /// </summary>
        public IList<DirectoryInfo> MappedDirectories { get; private set; }

        /// <summary>
        /// The file duplications founded.
        /// </summary>
        public IList<DuplicatedFile> DuplicatedFiles { get; private set; } = new List<DuplicatedFile>();

        /// <summary>
        /// The time taked by the duplication search operation.
        /// </summary>
        public TimeSpan SearchOperationDuration => Stopwatch == null ? new TimeSpan() : Stopwatch.Elapsed;

        #endregion

        #region Private Memebers

        /// <summary>
        /// The progress report provider.
        /// </summary>
        private IProgress<DuplicationSearchProgressReport> Progress { get; set; }

        /// <summary>
        /// The files mapped that has no duplications found.
        /// </summary>
        private IList<FileInfo> NonDuplicatedFiles { get; set; } = new List<FileInfo>();

        /// <summary>
        /// The stopwatch to measure the search operation time.
        /// </summary>
        private Stopwatch Stopwatch { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the <see cref="DuplicateFinder"/>.
        /// The search will be performed with the <see cref="DuplicationSearchWay.NameAndSizeComparison"/> way
        /// and with the minimun size for analysis set as 0.
        /// </summary>
        /// <param name="directoryPath">The path where the duplications search will be performed.</param>
        public DuplicateFinder(string directoryPath)
        {
            SelectedDirectory = new DirectoryInfo(directoryPath);
            Progress = new Progress<DuplicationSearchProgressReport>();
            CancelTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DuplicateFinder"/>.
        /// The search will be performed with the specified way
        /// and with the minimun size for analysis set as 0.
        /// </summary>
        /// <param name="directoryPath">The path where the duplications search will be performed.</param>
        /// <param name="searchWay">The way used for the duplication search.</param>
        public DuplicateFinder(string directoryPath, DuplicationSearchWay searchWay) 
            : this(directoryPath)
        {
            SearchWay = searchWay;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DuplicateFinder"/>.
        /// The search will be performed with the <see cref="DuplicationSearchWay.NameAndSizeComparison"/> way
        /// and with the minimun size for analysis provided.
        /// </summary>
        /// <param name="directoryPath">The path where the duplications search will be performed.</param>
        /// <param name="minimunSizeForAnalysis">The minimun size needed for the file to be analysed.</param>
        public DuplicateFinder(string directoryPath, long minimunSizeForAnalysis)
            : this(directoryPath)
        {
            MinimunSizeForAnalysis = minimunSizeForAnalysis;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DuplicateFinder"/>.
        /// The search will be performed with the specified way
        /// and with the minimun size for analysis provided.
        /// </summary>
        /// <param name="directoryPath">The path where the duplications search will be performed.</param>
        /// <param name="searchWay">The way used for the duplication search.</param>
        /// <param name="minimunSizeForAnalysis">The minimun size needed for the file to be analysed.</param>
        public DuplicateFinder(string directoryPath, DuplicationSearchWay searchWay, long minimunSizeForAnalysis)
            : this(directoryPath, minimunSizeForAnalysis)
        {
            SearchWay = searchWay;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Start the search of the duplicates.
        /// </summary>
        public void FindDuplicates()
        {
            try
            {
                StartSearch(CancelTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                Status = DuplicateSearchStatus.Canceled;
                ReportStatus("The operation has been canceled");
            }

            catch (Exception)
            {
                ReportStatus("Error");
            }
        }

        /// <summary>
        /// Start the asyncronous duplicates search.
        /// </summary>
        /// <returns></returns>
        public async Task FindDuplicatesAsync()
        {
            try
            {
                await Task.Run(() => StartSearch(CancelTokenSource.Token));
            }
            catch (OperationCanceledException)
            {
                Status = DuplicateSearchStatus.Canceled;
                ReportStatus("The operation has been canceled");
            }
            catch (Exception)
            {
                ReportStatus("Error");
            }
        }

        /// <summary>
        /// Cancel the search.
        /// </summary>
        public void Cancel()
        {
            CancelTokenSource.Cancel();
        }

        #endregion

        #region Private methods

        private void StartSearch(CancellationToken cancellationToken)
        {
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
            Status = DuplicateSearchStatus.StartingSearch;
            ReportStatus($"Starting search at: { DateTime.Now.ToLongTimeString() }. {(MinimunSizeForAnalysis > 0 ? $"The file size threshold is set in: {MinimunSizeForAnalysis} bytes" : "No size threshold setted")}.");
            MapDirectories(cancellationToken);
            SearchDuplicated(cancellationToken);
            Stopwatch.Stop();
            SearchPercentage = 100;
            Status = DuplicateSearchStatus.SearchFinished;
            ReportStatus($"Duplications search finished at { DateTime.Now.ToLongTimeString() }! The search operation took { Stopwatch.Elapsed }.");
        }

        private void ReportStatus(string message)
        {
            Progress.Report(new DuplicationSearchProgressReport
            {
                CurrentOperation = Status,
                CurrentDirectory = CurrentDirectory?.FullName,
                Percentage = SearchPercentage,
                Details = message
            });
        }

        private void ReportDuplication(string message)
        {
            Status = DuplicateSearchStatus.DuplicationFounded;
            Progress.Report(new DuplicationSearchProgressReport
            {
                CurrentOperation = Status,
                CurrentDirectory = CurrentDirectory?.FullName,
                Percentage = SearchPercentage,
                Details = message
            });
        }

        /// <summary>
        /// Map all the directories in the selected one.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for operation abort.</param>
        /// <returns></returns>
        private void MapDirectories(CancellationToken cancellationToken)
        {
            try
            {
                Status = DuplicateSearchStatus.MappingDirectories;
                ReportStatus("Start mapping directories.");
                MappedDirectories = MapDirectories(SelectedDirectory, cancellationToken);
                ReportStatus($"Finished directory mapping in {(Stopwatch.Elapsed.TotalSeconds > 60 ? $"{Stopwatch.Elapsed.TotalMinutes} minutes" : $"{Stopwatch.Elapsed.TotalSeconds} seconds")}.");
            }
            catch (OperationCanceledException)
            {
                Status = DuplicateSearchStatus.Canceled;
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all the subdirectories in the specified one.
        /// </summary>
        /// <param name="directory">The directory to get all the subdirectories.</param>
        /// <param name="cancellationToken">The cancellation token for operation abort.</param>
        /// <returns>The full list of the subdirectories in the specified one.</returns>
        private IList<DirectoryInfo> MapDirectories(DirectoryInfo directory, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                Status = DuplicateSearchStatus.MappingDirectories;
                ReportStatus("Mapping directory.");
                var baseDirectories = directory.GetDirectories();
                var mappedDirectories = baseDirectories.ToList();
                foreach (var dir in baseDirectories)
                {
                    mappedDirectories.AddRange(MapDirectories(dir, cancellationToken));
                }
                return mappedDirectories;
            }
            catch (UnauthorizedAccessException ex)
            {
                Status = DuplicateSearchStatus.Error;
                ReportStatus($"Error accessing folder. Details: {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                Status = DuplicateSearchStatus.Error;
                ReportStatus($"Error accessing folder. Details: {ex.Message}");
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return new List<DirectoryInfo>();
        }

        private void SearchDuplicated(CancellationToken cancellationToken)
        {
            Status = DuplicateSearchStatus.SearchingDuplicates;
            ReportStatus("Duplication search started!");
            var dircount = 0;
            foreach (var dir in MappedDirectories)
            {
                cancellationToken.ThrowIfCancellationRequested();
                CurrentDirectory = dir;
                dircount++;
                SearchPercentage = Math.Round(
                    Convert.ToDouble(dircount) / Convert.ToDouble(MappedDirectories.Count) * 100,
                    MidpointRounding.ToEven);
                try
                {
                    var files = dir.EnumerateFiles();
                    foreach (var file in files)
                    {
                        if (file.Length >= MinimunSizeForAnalysis)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            Status = DuplicateSearchStatus.SearchingDuplicates;
                            ReportStatus($"Analizing file. {file.FullName}");
                            var existentDuplication = SearchWay == DuplicationSearchWay.NameAndSizeComparison
                                ? DuplicatedFiles.FirstOrDefault(
                                                        df => df.FileName == file.Name && df.AverageFileSize == file.Length)
                                : DuplicatedFiles.FirstOrDefault(
                                                        df => CompareFileHashes(file, df.Files.FirstOrDefault()));
                            if (existentDuplication != null)
                            {
                                ReportDuplication($"Duplication founded at: {file.FullName} with {string.Join(", ", existentDuplication.Files.Select(d => d.FullName))}");
                                existentDuplication.Files.Add(file);
                            }
                            else
                            {
                                var duplicatedFile = SearchWay == DuplicationSearchWay.NameAndSizeComparison
                                    ? NonDuplicatedFiles.FirstOrDefault(
                                                                f => f.Name == file.Name && f.Length == file.Length)
                                    : NonDuplicatedFiles.FirstOrDefault(
                                                                f => CompareFileHashes(file, f));
                                if (duplicatedFile != null)
                                {
                                    ReportDuplication($"Duplication founded at: {file.FullName} with {duplicatedFile.FullName}");
                                    var duplication = new DuplicatedFile
                                    {
                                        FileName = duplicatedFile.Name,
                                        Files = new List<FileInfo>
                                        {
                                            duplicatedFile,
                                            file
                                        }
                                    };
                                    DuplicatedFiles.Add(duplication);
                                    _ = NonDuplicatedFiles.Remove(duplicatedFile);
                                }
                                else
                                {
                                    NonDuplicatedFiles.Add(file);
                                }
                            }
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (UnauthorizedAccessException ex)
                {
                    Status = DuplicateSearchStatus.Error;
                    ReportStatus($"Access denied to the current folder. Details: {ex.Message}");
                    continue;
                }
                catch (DirectoryNotFoundException ex)
                {
                    Status = DuplicateSearchStatus.Error;
                    ReportStatus($"Directory not found. Details: {ex.Message}");
                    continue;
                }
                catch (SecurityException)
                {
                    Status = DuplicateSearchStatus.Error;
                    ReportStatus("Security exception.");
                    continue;
                }
            }
        }

        /// <summary>
        /// Compares 2 files to determine if are equals using the hash compare method.
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <returns><see langword="true"/> if the files are equals.</returns>
        private static bool CompareFileHashes(FileInfo file1, FileInfo file2)
        {
            if (file1.Length == file2.Length)
            {
                using (var hash = HashAlgorithm.Create())
                {
                    byte[] fileHash1, fileHash2;

                    using (FileStream fileStream1 = new FileStream(file1.FullName, FileMode.Open),
                                      fileStream2 = new FileStream(file2.FullName, FileMode.Open))
                    {
                        fileHash1 = hash.ComputeHash(fileStream1);
                        fileHash2 = hash.ComputeHash(fileStream2);
                    }

                    return BitConverter.ToString(fileHash1) == BitConverter.ToString(fileHash2);
                }
            }
            return false;
        }

        #endregion
    }
}
