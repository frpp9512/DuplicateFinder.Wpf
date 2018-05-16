using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFinder
{
    class DuplicatedFile
    {
        public Bitmap Icon
        {
            get
            {
                try
                {
                    return Files.Count > 0 ? System.Drawing.Icon.ExtractAssociatedIcon(Files[0].FullName).ToBitmap() : null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public string FileName { get; set; }
        public List<FileInfo> Files { get; set; } = new List<FileInfo>();
        public int TimesRepeated { get => Files.Count; }
        public long AverageFileSize { get => Files.Count > 0 ? TotalDuplicationSize / Files.Count : 0; }
        public long TotalDuplicationSize { get => Files.Sum(f => f.Length); }
    }
}
