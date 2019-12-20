using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// Represents the way to perform the search duplications.
    /// </summary>
    public enum DuplicationSearchWay
    {
        /// <summary>
        /// Determines the file's equality by comparing the name and size.
        /// </summary>
        NameAndSizeComparison,

        /// <summary>
        /// Detemines the file's equality by comparing the unique hash of the files.
        /// </summary>
        HashComparison
    }
}
