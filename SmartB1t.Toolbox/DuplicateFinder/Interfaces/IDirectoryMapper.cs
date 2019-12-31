using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// Represents a directory mapper in a storage device.
    /// </summary>
    public interface IDirectoryMapper
    {
        /// <summary>
        /// Gets the directories contained in a specific route.
        /// </summary>
        /// <param name="route">The route where the directories will be mapped.</param>
        /// <returns>The collection of directories mapped in the specific route.</returns>
        IList<IDirectoryMapped> GetDirectories(string route);
    }
}
