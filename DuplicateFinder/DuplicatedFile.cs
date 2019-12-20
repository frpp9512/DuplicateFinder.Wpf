using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFinder
{
    /// <summary>
    /// Represents a set of duplicated files in a storage device.
    /// </summary>
    public class DuplicatedFile
    {
        /// <summary>
        /// The name of the duplicated files.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The info of the duplicated files.
        /// </summary>
        public List<FileInfo> Files { get; set; } = new List<FileInfo>();

        /// <summary>
        /// The times the files are repeated.
        /// </summary>
        public int TimesRepeated => Files.Count;

        /// <summary>
        /// The average file size of the duplicated files.
        /// </summary>
        public long AverageFileSize => Files.Count > 0 ? TotalDuplicationSize / Files.Count : 0;

        /// <summary>
        /// The total size of all duplicated files.
        /// </summary>
        public long TotalDuplicationSize => Files.Sum(f => f.Length);

        /// <summary>
        /// The space that are lost by the duplications.
        /// </summary>
        public long SpaceLostByDuplication => TotalDuplicationSize - AverageFileSize;
    }
}
