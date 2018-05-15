using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFinder
{
    class DuplicatedFile
    {
        public string FileName { get; set; }
        public List<FileInfo> Files { get; set; }
        public int TimesRepeated { get => Files.Count; }
    }
}
