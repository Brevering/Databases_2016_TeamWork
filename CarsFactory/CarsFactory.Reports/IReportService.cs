using CarsFactory.Data.Contracts;

namespace CarsFactory.Reports
{
    /// <summary>
    /// Specifies an interface for a report generation service.
    /// </summary>
    public interface IReportService
    {
        void SaveAllReports(string directoryPath, ICarsFactoryDbContext dbContext);
    }
}
