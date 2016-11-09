using System.IO;

using CarsFactory.Reports.Files.Contracts;

namespace CarsFactory.Reports.Files
{
    /// <summary>
    /// Provides methods for creating directories and file streams.
    /// </summary>
    public class FileDirectoryProvider : IFileDirectoryProvider
    {
        /// <summary>
        /// Checks if a given directory exists.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns>True if a directory exists, false otherwise.</returns>
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// Creates a directory at the specified location.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Creates a new filestream.
        /// </summary>
        /// <param name="filePath">The path to the output file.</param>
        /// <returns>A FileStream.</returns>
        public Stream CreateFileStream(string filePath)
        {
            return new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        }
    }
}
