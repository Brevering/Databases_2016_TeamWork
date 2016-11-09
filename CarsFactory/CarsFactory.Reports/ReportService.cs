using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using CarsFactory.Data.Contracts;
using CarsFactory.Reports.ReportManagers.Contracts;
using CarsFactory.Reports.Reports.Contracts;

namespace CarsFactory.Reports
{
    /// <summary>
    /// Provides method for the generation of reports.
    /// </summary>
    public class ReportService : IReportService
    {
        private readonly IEnumerable<IReportManager> reportManagers;

        public ReportService(IEnumerable<IReportManager> reportManagers)
        {
            if (reportManagers == null)
            {
                throw new ArgumentNullException(nameof(reportManagers));
            }

            this.reportManagers = reportManagers;
        }

        /// <summary>
        /// Saves all IReports in the assembly in the specified directory.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="dbContext"></param>
        public void SaveAllReports(string directoryPath, ICarsFactoryDbContext dbContext)
        {
            var allReports = this.GetAllReports();

            var enumerableReports = allReports as IReport[] ?? allReports.ToArray();
            using (dbContext)
            {
                foreach (var reportManager in this.reportManagers)
                {
                    reportManager.Add(enumerableReports);
                    reportManager.GenerateReports(directoryPath, dbContext);
                }
            }
        }

        /// <summary>
        /// Gets an instance of each implementation of IReport.
        /// </summary>
        /// <returns>A collection of instantiated IReports.</returns>
        private IEnumerable<IReport> GetAllReports()
        {
            var assembly = this.GetType()
                               .GetTypeInfo()
                               .Assembly;
            IEnumerable<Type> typeInfos = assembly.DefinedTypes
                                                  .Where(type => type.ImplementedInterfaces
                                                                     .Any(inter => inter == typeof(IReport))
                );
            var result = typeInfos.Select(typeInfo => Activator.CreateInstance(typeInfo) as IReport)
                                  .ToList();
            return result;
        }
    }
}
