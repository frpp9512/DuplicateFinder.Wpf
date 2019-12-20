using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// Represents a duplicated file in the storage device. 
    /// It contains the the reference of all the duplications.
    /// </summary>
    public class DuplicatedFile
    {
        /// <summary>
        /// The file icon
        /// </summary>
        public Bitmap Icon
        {
            get
            {
                try
                {
                    var file = Files.FirstOrDefault(f => f.Exists);
                    return file == null ? null : System.Drawing.Icon.ExtractAssociatedIcon(file.FullName).ToBitmap();
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// The name of the duplicate file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The <see cref="FileInfo"/> instances for the duplications.
        /// </summary>
        public IList<FileInfo> Files { get; set; } = new List<FileInfo>();

        /// <summary>
        /// The total times the file is repeated.
        /// </summary>
        public int TimesRepeated => Files.Count;

        /// <summary>
        /// The average file size of the duplicated file.
        /// </summary>
        public long AverageFileSize => Files.Count > 0 ? TotalDuplicationSize / Files.Count : 0;

        /// <summary>
        /// The total size of all duplicated files.
        /// </summary>
        public long TotalDuplicationSize => Files.Sum(f => f.Length);

        /// <summary>
        /// The space lost by having duplicated files.
        /// </summary>
        public long SpaceLostByDuplication => TotalDuplicationSize - AverageFileSize;
    }
}
