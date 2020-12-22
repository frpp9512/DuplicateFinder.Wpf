using System.Collections.Generic;
using System.Drawing;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// Represents a duplicated file in the storage device. 
    /// It contains the the reference of all the duplications.
    /// </summary>
    public interface IDuplicatedFile
    {
        /// <summary>
        /// The file icon
        /// </summary>
        Bitmap Icon { get; }

        /// <summary>
        /// The name of the duplicate file.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// The <see cref="IAnalysedFile"/> instances for the duplications.
        /// </summary>
        IList<IAnalysedFile> Files { get; set; }

        /// <summary>
        /// The average file size of the duplicated file.
        /// </summary>
        long AverageFileSize { get; }

        /// <summary>
        /// The space lost by having duplicated files.
        /// </summary>
        long SpaceLostByDuplication { get; }

        /// <summary>
        /// The total times the file is repeated.
        /// </summary>
        int TimesRepeated { get; }

        /// <summary>
        /// The total size of all duplicated files.
        /// </summary>
        long TotalDuplicationSize { get; }
    }
}