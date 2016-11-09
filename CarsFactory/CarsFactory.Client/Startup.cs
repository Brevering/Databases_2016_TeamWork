using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

using CarsFactory.Data.Contracts;
using CarsFactory.Reports;
using CarsFactory.Reports.ReportManagers.Contracts;

using Ninject;
using CarsFactory.Reports.Reports;
using CarsFactory.MongoDb.Data;
using CarsFactory.MongoDb.Data.Contracts;
using CarsFactory.Reports.Contracts;

namespace CarsFactory.Client
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var dbContext = kernel.Get<ICarsFactoryDbContext>();

            // Problem 2
            var reportService = kernel.Get<IReportService>();
            reportService.SaveAllReports(@"..\..\..\Output\", dbContext);

            /*
                Problem 4 - JSON Reports
                After db is populated this will create the JSON reports
                and save them all to the file system, named as per requirement
                as well as to a MySQL database as JSON objects
            
            var jsonReport = kernel.Get<IGenerateJsonReport>();
            jsonReport.GenerateJson();
            */


            // Problem 1 - Write data in SQL Database from Zip files.
            var repo = kernel.Get<IMongoDbRepository>();
            var mssqlRepo = kernel.Get<IMsSqlRepository>();
            var zipFiles = kernel.Get<IGenerateDataFromZipFiles>();
            var mongoData = kernel.Get<IGenerateDataFromMongoDb>();
            var filePath = @"..\..\..\..\Input\SampleData.zip";
            zipFiles.SaveAllDataFromZip(mssqlRepo, dbContext, filePath);
            // Write data in MSSQL Database from MongoDb
            Task.Run(async () =>
            {
                await mongoData.SaveAllMongoData(repo, mssqlRepo, dbContext);
            }).Wait();


            //   Task 3
            var xmlReport = kernel.Get<IGenerateXmlReport>();
            xmlReport.CreateReport();

        }
    }
}
