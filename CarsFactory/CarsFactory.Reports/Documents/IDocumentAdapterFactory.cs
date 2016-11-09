using System.IO;

using CarsFactory.Reports.Documents.Contracts;

namespace CarsFactory.Reports.Documents
{
    /// <summary>
    /// Provides an interface for instantiating different IDocumentAdapters.
    /// </summary>
    public interface IDocumentAdapterFactory
    {
        IDocumentAdapter GetPdfDocumentAdapter(string fileName, Stream stream);
    }
}
