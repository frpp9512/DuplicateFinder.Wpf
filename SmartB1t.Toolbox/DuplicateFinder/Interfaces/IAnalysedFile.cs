using System;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// Represents a file analysed by the duplicate finder.
    /// </summary>
    public interface IAnalysedFile : IComparable
    {
        /// <summary>
        /// The name of the analysed file.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The fullpath of the analysed file.
        /// </summary>
        string FullName { get; set; }

        /// <summary>
        /// The length of the file in bytes.
        /// </summary>
        long Length { get; set; }

        /// <summary>
        /// <see langword="true"/> if the file exists in the storage device.
        /// </summary>
        bool Exists { get; set; }

        /// <summary>
        /// The hash generated for the analysed file.
        /// </summary>
        string Hash { get; set; }

        /// <summary>
        /// Create the file hash.
        /// </summary>
        void CreateHash();
    }
}