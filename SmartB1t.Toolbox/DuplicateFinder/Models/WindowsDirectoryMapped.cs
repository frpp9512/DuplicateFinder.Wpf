using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// A directory mapped from a storage device with a file system compatible with Windows devices.
    /// It uses the <see cref="AnalysedFile"/> implementation of <see cref="IAnalysedFile"/>.
    /// </summary>
    public class WindowsDirectoryMapped : IDirectoryMapped
    {
        /// <summary>
        /// Creates a new instance of <see cref="WindowsDirectoryMapped"/>.
        /// </summary>
        /// <param name="directoryMapper">The <see cref="IDirectoryMapper"/> instance used for map the subdirectories.</param>
        public WindowsDirectoryMapped(IDirectoryMapper directoryMapper)
        {
            DirectoryMapper = directoryMapper;
        }

        /// <summary>
        /// The Directory Info instance of the mapped directory.
        /// </summary>
        public DirectoryInfo DirectoryInfo { get; set; }
        public string Name { get => DirectoryInfo.Name; set { return; } }
        public string Fullname { get => DirectoryInfo.FullName; set { return; } }
        public IDirectoryMapper DirectoryMapper { get; set; }

        public IList<IDirectoryMapped> GetDirectories() => DirectoryMapper.GetDirectories(Fullname);

        public IList<IAnalysedFile> GetFiles() => DirectoryInfo.EnumerateFiles().Select(f => (IAnalysedFile)new AnalysedFile { File = f }).ToList();
    }
}