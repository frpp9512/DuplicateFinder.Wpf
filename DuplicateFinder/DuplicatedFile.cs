﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFinder
{
    public class DuplicatedFile
    {
        public string FileName { get; set; }
        public List<FileInfo> Files { get; set; } = new List<FileInfo>();
        public int TimesRepeated { get => Files.Count; }
        public long AverageFileSize { get => Files.Count > 0 ? TotalDuplicationSize / Files.Count : 0; }
        public long TotalDuplicationSize { get => Files.Sum(f => f.Length); }
        public long SpaceLostByDuplication { get => TotalDuplicationSize - AverageFileSize; }
    }
}
