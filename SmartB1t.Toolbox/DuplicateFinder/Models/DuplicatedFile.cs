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
    public class DuplicatedFile : IDuplicatedFile
    {
        
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

        
        public string FileName { get; set; }

        
        public IList<IAnalysedFile> Files { get; set; }

        
        public int TimesRepeated => Files.Count;

        
        public long AverageFileSize => Files.Count > 0 ? TotalDuplicationSize / Files.Count : 0;

        
        public long TotalDuplicationSize => Files.Sum(f => f.Length);

        
        public long SpaceLostByDuplication => TotalDuplicationSize - AverageFileSize;
    }
}
