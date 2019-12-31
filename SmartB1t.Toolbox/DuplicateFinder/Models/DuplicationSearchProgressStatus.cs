using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// Represents an status of the Duplicate Search process.
    /// </summary>
    public class DuplicationSearchProgressReport
    {
        /// <summary>
        /// The current running process operation.
        /// </summary>
        public DuplicateSearchStatus CurrentOperation { get; set; }

        /// <summary>
        /// The current directory in search.
        /// </summary>
        public string CurrentDirectory { get; set; }

        /// <summary>
        /// The current completion percentage.
        /// </summary>
        public double Percentage { get; set; }

        /// <summary>
        /// The current operation status details.
        /// </summary>
        public string Details { get; set; }
    }
}
