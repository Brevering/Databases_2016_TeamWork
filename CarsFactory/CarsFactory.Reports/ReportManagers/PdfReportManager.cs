using System.IO;

using CarsFactory.Reports.Documents;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.Files.Contracts;
using CarsFactory.Reports.ReportManagers.Abstract;

namespace CarsFactory.Reports.ReportManagers
{
    /// <summary>
    /// Provides methods for the generation of PDF reports.
    /// </summary>
    public class PdfReportManager : ReportManager
    {
        private const string FileExtension = ".pdf";

        public PdfReportManager(IFileDirectoryProvider fileDirectoryProvider, IDocumentAdapterFactory documentAdapterFactory) 
            : base(fileDirectoryProvider, documentAdapterFactory)
        {
        }

        /// <summary>
        /// Creates a PdfDocumentAdapter.
        /// </summary>
        /// <param name="fileName">The file path.</param>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>A PdfDocumentAdapter.</returns>
        protected override IDocumentAdapter CreateDocument(string fileName, Stream stream)
        {
            return this.DocumentAdapterAdapterFactory.GetPdfDocumentAdapter(fileName, stream);
        }

        /// <summary>
        /// Appends .pdf extension to a filename if missing.
        /// </summary>
        /// <returns>Full name and extension.</returns>
        protected override string AppendFileExtension(string fileName)
        {
            if (fileName.EndsWith(FileExtension))
            {
                return fileName;
            }

            return fileName + FileExtension;
        }
    }
}
