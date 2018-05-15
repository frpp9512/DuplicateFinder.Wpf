using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace DuplicateFinder
{
    class DuplicateFinder
    {
        public DirectoryInfo SelectedDirectory { get; set; }
        public List<DuplicatedFile> Duplicates { get; private set; }
        public int DirectoriesCount { get; private set; }
        public int ProcessedDirectoriesCount { get; private set; }
        public Progress<DuplicateSearchProgress> Progress { get; private set; } = new Progress<DuplicateSearchProgress>();
        CancellationTokenSource Cancellation { get; } = new CancellationTokenSource(); 
        public long TotalSpaceInDuplicates { get => Duplicates.Sum(d => d.TotalDuplicationSize); }
        public long TotalSpaceLostByDuplicates { get => TotalSpaceInDuplicates - Duplicates.Sum(d => d.AverageFileSize); }

        public async Task StartSearchOfDuplicates()
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

        private List<DuplicatedFile> FindDuplicates(DirectoryInfo folder, CancellationToken cancel, List<FileInfo> accumulatedFiles = null, List<DuplicatedFile> accumulatedDuplicated = null)
        {
            DirectoryInfo current = folder;

            IEnumerable<DirectoryInfo> dirs;

            IEnumerable<FileInfo> currentFiles;

            try
            {
                dirs = current.EnumerateDirectories();
                currentFiles = current.EnumerateFiles();
            }
            catch (Exception ex)
            {
                (Progress as IProgress<DuplicateSearchProgress>).Report(new DuplicateSearchProgress { Operation = DuplicateSearchOperation.ErrorFound, AdditionalInformation = ex.Message });
                return accumulatedDuplicated;
            }
            
            if(accumulatedDuplicated == null)
            {
                accumulatedDuplicated = new List<DuplicatedFile>();
            }
            if (accumulatedFiles == null)
            {
                accumulatedFiles = currentFiles.ToList();
            }
            else
            {
                foreach (var file in currentFiles)
                {
                    dynamic result = accumulatedFiles.Where(f => f.Name == file.Name && f.Length == file.Length);
                    if ((result as IEnumerable<FileInfo>).Count() > 0)
                    {
                        DuplicatedFile df = new DuplicatedFile { FileName = file.Name };
                        df.Files.Add(file);
                        df.Files.Add((result as IEnumerable<FileInfo>).ElementAt(0));
                        accumulatedDuplicated.Add(df);
                        accumulatedFiles.Remove((result as IEnumerable<FileInfo>).ElementAt(0));
                    }
                    else
                    {
                        result = accumulatedDuplicated.Where(d => d.FileName == file.Name && d.AverageFileSize == file.Length);
                        if ((result as IEnumerable<DuplicatedFile>).Count() > 0)
                        {
                            DuplicatedFile df = (result as IEnumerable<DuplicatedFile>).ElementAt(0);
                            df.Files.Add(file);
                        }
                        else
                        {
                            accumulatedFiles.Add(file);
                        }
                    }
                }
                ProcessedDirectoriesCount++;
            }

            (Progress as IProgress<DuplicateSearchProgress>).Report(new DuplicateSearchProgress { Operation = DuplicateSearchOperation.SearchingDuplicates, CurrentDirectory = current.FullName, Percentage = ProcessedDirectoriesCount * 100 / DirectoriesCount });
            cancel.ThrowIfCancellationRequested();

            foreach (var dir in dirs)
            {
                FindDuplicates(dir, cancel, accumulatedFiles, accumulatedDuplicated);
            }

            return accumulatedDuplicated;
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
            int count = directories.Count();
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
