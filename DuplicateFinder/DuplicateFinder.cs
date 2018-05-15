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
        CancellationTokenSource Cancellation { get; } = new CancellationTokenSource();        

        public async Task<List<DuplicatedFile>> StartSearchDuplicated(string folderPath, IProgress<FilesProgress> progress)
        {
            List<DuplicatedFile> duplicates = await Task.Run(() => FindDuplicates(folderPath, progress, Cancellation.Token, new List<FileInfo>(), new List<DuplicatedFile>()));
            return duplicates;
        }

        public List<DuplicatedFile> FindDuplicates(string folderPath, IProgress<FilesProgress> progress, CancellationToken cancel, List<FileInfo> accumulatedFiles, List<DuplicatedFile> accumulatedDuplicated)
        {
            List<DuplicatedFile> duplicates = new List<DuplicatedFile>();

            DirectoryInfo current = new DirectoryInfo(folderPath);
            IEnumerable<DirectoryInfo> dirs = current.EnumerateDirectories();

            IEnumerable<FileInfo> currentFiles = current.EnumerateFiles();

            if (accumulatedFiles.Count == 0)
            {
                accumulatedFiles = currentFiles.ToList();
            }
            else
            {
                foreach (var file in currentFiles)
                {
                    dynamic result = accumulatedFiles.Where(f => f.Name == file.Name);
                    if (result.Count() > 0)
                    {
                        DuplicatedFile df = new DuplicatedFile { FileName = file.Name };
                        df.Files.Add(file);
                        df.Files.Add(result.ElementAt(0));
                        duplicates.Add(df);
                        accumulatedFiles.Remove(result.ElementAt(0));
                    }
                    else
                    {
                        result = accumulatedDuplicated.Where(d => d.FileName == file.Name);
                        if(result.Count() > 0)
                        {

                        }
                        accumulatedFiles.Add(file);
                    }
                }
            }

            foreach (var dir in dirs)
            {

            }

            return duplicates;
        }

        public int StartGetDirectoriesCount(string folderPath)
        {
            return GetDirectoriesCount(folderPath, Cancellation.Token);
        }

        private int GetDirectoriesCount(string folderPath, CancellationToken cancel)
        {
            cancel.ThrowIfCancellationRequested();
            DirectoryInfo current = new DirectoryInfo(folderPath);
            IEnumerable<DirectoryInfo> directories = current.EnumerateDirectories();
            int count = directories.Count();
            foreach (var dir in directories)
            {
                count += GetDirectoriesCount(dir.FullName, cancel);
            }
            return count;
        }

        public void CancelAll()
        {
            Cancellation.Cancel();
        }
    }
}
