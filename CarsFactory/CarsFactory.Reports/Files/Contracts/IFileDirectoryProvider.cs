using System.IO;

namespace CarsFactory.Reports.Files.Contracts
{
    /// <summary>
    /// Provides an interface for directory and file management.
    /// </summary>
    public interface IFileDirectoryProvider
    {
        bool DirectoryExists(string path);

        void CreateDirectory(string path);

        Stream CreateFileStream(string filePath);
    }
}
