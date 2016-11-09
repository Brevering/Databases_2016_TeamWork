using System.Collections.Generic;

namespace CarsFactory.Reports.Documents.Contracts
{
    /// <summary>
    /// Provides methods to abstract different kinds of documents from their implementation.
    /// </summary>
    public interface IDocumentAdapter
    {
        string FileLocation { get; }

        IDocumentAdapter AddHeader(string text);

        IDocumentAdapter AddTabularData<T>(ICollection<T> tableData);

        IDocumentAdapter NewPage();

        IDocumentAdapter AddMetadata();

        void Save();
    }
}
