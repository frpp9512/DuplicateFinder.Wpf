using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    /// <summary>
    /// Represents an analysed file by the duplicate finder represented by a FileInfo.
    /// </summary>/
    public class AnalysedFile : IAnalysedFile
    {
        public FileInfo File { get; set; }
        public string Name { get => File.Name; set { return; } }
        public string FullName { get => File.FullName; set { return; } }
        public long Length { get => File.Length; set { return; } }
        public string Hash { get; set; }
        public bool Exists { get => File.Exists; set { return; } }

        public int CompareTo(object obj) => obj is IAnalysedFile analysedFile
                ? !string.IsNullOrEmpty(Hash) && !string.IsNullOrEmpty(analysedFile.Hash)
                    ? analysedFile.Hash == Hash ? 0 : -1
                    : analysedFile.Name == Name && analysedFile.Length == Length ? 0 : -1
                : -1;

        public void CreateHash()
        {
            if (string.IsNullOrEmpty(Hash))
            {
                using (var hash = HashAlgorithm.Create())
                {
                    byte[] fileHash;
                    using (var fileStream = new FileStream(FullName, FileMode.Open))
                    {
                        fileHash = hash.ComputeHash(fileStream);
                    }
                    Hash = BitConverter.ToString(fileHash);
                } 
            }
        }

        public override string ToString() => FullName;
    }
}
