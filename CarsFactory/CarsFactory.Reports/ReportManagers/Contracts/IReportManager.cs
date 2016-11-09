using System.Collections.Generic;

using CarsFactory.Data.Contracts;
using CarsFactory.Reports.Reports.Contracts;

namespace CarsFactory.Reports.ReportManagers.Contracts
{
    /// <summary>
    /// Specifies an interface for controlling groups of reports.
    /// </summary>
    public interface IReportManager
    {
        void GenerateReports(string directoryLocation, ICarsFactoryDbContext dbContext);

        void Add(IReport report);

        void Add(IEnumerable<IReport> reports);
    }
}
