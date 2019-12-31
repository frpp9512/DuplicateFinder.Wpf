using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// A directory mapper for a Windows file system compatibles storage devices.
    /// It uses the <see cref="WindowsDirectoryMapped"/> implementation of <see cref="IDirectoryMapped"/>.
    /// </summary>
    public class BasicWindowsDirectoryMapper : IDirectoryMapper
    {
        public IList<IDirectoryMapped> GetDirectories(string route)
        {
            try
            {
                if (!Directory.Exists(route))
                {
                    throw new DirectoryNotFoundException($"The {route} directory wasn't found.");
                }
                return Directory.GetDirectories(route)
                    .Select(d => new DirectoryInfo(d))
                    .Select(di => (IDirectoryMapped)new WindowsDirectoryMapped(this) { DirectoryInfo = di })
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}