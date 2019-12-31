using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// Represents a directory mapped in a storage location.
    /// </summary>
    public interface IDirectoryMapped
    {
        /// <summary>
        /// The name of the directory mapped.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The full path of the directory maped.
        /// </summary>
        string Fullname { get; set; }

        /// <summary>
        /// The <see cref="IDirectoryMapped"/> instance used for map for the child directories.
        /// </summary>
        IDirectoryMapper DirectoryMapper { get; set; }

        /// <summary>
        /// Gets the files contained in the directory.
        /// </summary>
        /// <returns>The collection of files contained in the directory.</returns>
        IList<IAnalysedFile> GetFiles();

        /// <summary>
        /// Gets the directories contained in the directory.
        /// </summary>
        /// <returns>The collection of directories contained in the directory.</returns>
        IList<IDirectoryMapped> GetDirectories();
    }
}
