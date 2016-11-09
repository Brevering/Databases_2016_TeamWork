using CarsFactory.Data.Contracts;
using CarsFactory.Reports.Documents.Contracts;

namespace CarsFactory.Reports.Reports.Contracts
{
    /// <summary>
    /// Provides an interface for a generatable report.
    /// </summary>
    public interface IReport
    {
        void Generate(IDocumentAdapter document, ICarsFactoryDbContext dbContext);
    }
}
