using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DuplicateFinder
{
    internal class DuplicateFinder
    {
        public DirectoryInfo SelectedDirectory { get; set; }
        public List<DuplicatedFile> Duplicates { get; private set; }
        public int DirectoriesCount { get; private set; }
        public int ProcessedDirectoriesCount { get; private set; }
        public Progress<DuplicateSearchProgress> Progress { get; private set; } = new Progress<DuplicateSearchProgress>();
        private CancellationTokenSource Cancellation { get; } = new CancellationTokenSource();
        public long TotalSpaceInDuplicates => Duplicates.Sum(d => d.TotalDuplicationSize);
        public long TotalSpaceLostByDuplicates => TotalSpaceInDuplicates - Duplicates.Sum(d => d.AverageFileSize);

        public async Task StartSearchOfDuplicatesAsync()
        {
            try
            {
                await Task.Run(() => StartGetDirectoriesCount());
            }
            catch (Exception)
            {
                throw;
            }
            try
            {
                await Task.Run(() => StartSearchDuplicated());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task StartSearchDuplicated()
        {
            Duplicates = await Task.Run(() => FindDuplicates(SelectedDirectory, Cancellation.Token));
        }

        private List<DuplicatedFile> FindDuplicates(DirectoryInfo directory, CancellationToken cancel, List<FileInfo> accumulated_files = null, List<DuplicatedFile> accumulated_duplications = null)
        {
            var current_directory = directory;

            IEnumerable<DirectoryInfo> sub_directories;

            IEnumerable<FileInfo> directory_files;

            try
            {
                sub_directories = current_directory.EnumerateDirectories();
                directory_files = current_directory.EnumerateFiles();
            }
            catch (Exception ex)
            {
                (Progress as IProgress<DuplicateSearchProgress>).Report(new DuplicateSearchProgress { Operation = DuplicateSearchOperation.ErrorFound, AdditionalInformation = ex.Message });
                return accumulated_duplications;
            }

            if (accumulated_files == null)
            {
                accumulated_duplications = new List<DuplicatedFile>();
                accumulated_files = directory_files.ToList();
            }
            else
            {
                foreach (var file in directory_files)
                {
                    dynamic result = accumulated_files.Where(f => f.Name == file.Name && f.Length == file.Length);
                    if ((result as IEnumerable<FileInfo>).Count() > 0)
                    {
                        var new_duplication = new DuplicatedFile { FileName = file.Name };
                        new_duplication.Files.Add(file);
                        new_duplication.Files.Add((result as IEnumerable<FileInfo>).ElementAt(0));
                        accumulated_duplications.Add(new_duplication);
                        _ = accumulated_files.Remove((result as IEnumerable<FileInfo>).ElementAt(0));
                    }
                    else
                    {
                        result = accumulated_duplications.Where(d => d.FileName == file.Name && d.AverageFileSize == file.Length);
                        if ((result as IEnumerable<DuplicatedFile>).Count() > 0)
                        {
                            var existing_duplication = (result as IEnumerable<DuplicatedFile>).ElementAt(0);
                            existing_duplication.Files.Add(file);
                        }
                        else
                        {
                            accumulated_files.Add(file);
                        }
                    }
                }
                ProcessedDirectoriesCount++;
            }

            (Progress as IProgress<DuplicateSearchProgress>).Report(new DuplicateSearchProgress { Operation = DuplicateSearchOperation.SearchingDuplicates, CurrentDirectory = current_directory.FullName, Percentage = ProcessedDirectoriesCount * 100 / DirectoriesCount });
            cancel.ThrowIfCancellationRequested();

            foreach (var dir in sub_directories)
            {
                _ = FindDuplicates(dir, cancel, accumulated_files, accumulated_duplications);
            }

            return accumulated_duplications;
        }

        private async Task StartGetDirectoriesCount()
        {
            (Progress as IProgress<DuplicateSearchProgress>).Report(new DuplicateSearchProgress { Operation = DuplicateSearchOperation.DetectingDirectories });
            DirectoriesCount = await Task.Run(() => GetDirectoriesCount(SelectedDirectory, Cancellation.Token));
        }

        private int GetDirectoriesCount(DirectoryInfo directory, CancellationToken cancel)
        {
            cancel.ThrowIfCancellationRequested();
            IEnumerable<DirectoryInfo> directories;
            try
            {
                directories = directory.EnumerateDirectories();
            }
            catch (Exception ex)
            {
                (Progress as IProgress<DuplicateSearchProgress>).Report(new DuplicateSearchProgress { Operation = DuplicateSearchOperation.ErrorFound, AdditionalInformation = ex.Message });
                return 0;
            }
            var count = directories.Count();
            foreach (var dir in directories)
            {
                count += GetDirectoriesCount(dir, cancel);
            }
            return count;
        }

        public void CancelAll()
        {
            Cancellation.Cancel();
        }
    }
}
