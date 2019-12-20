using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// Represents the current Duplicate Search running operation.
    /// </summary>
    public enum DuplicateSearchStatus
    {
        /// <summary>
        /// When the search process is starting up.
        /// </summary>
        StartingSearch,

        /// <summary>
        /// When the process is mapping all the subdirectories of the given path.
        /// </summary>
        MappingDirectories,

        /// <summary>
        /// When the process is searching duplication in an specific directory. 
        /// </summary>
        SearchingDuplicates,

        /// <summary>
        /// When the process has found a file duplication.
        /// </summary>
        DuplicationFounded,

        /// <summary>
        /// When the search process has finished.
        /// </summary>
        SearchFinished,

        /// <summary>
        /// When the process has been canceled.
        /// </summary>
        Canceled,

        /// <summary>
        /// When an error has been found in the process.
        /// </summary>
        Error
    }
}
