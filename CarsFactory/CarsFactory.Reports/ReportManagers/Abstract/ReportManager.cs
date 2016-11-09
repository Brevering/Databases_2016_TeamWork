using System;
using System.Collections.Generic;
using System.IO;

using CarsFactory.Data.Contracts;
using CarsFactory.Reports.Documents;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.Reports.Contracts;
using CarsFactory.Reports.Files.Contracts;
using CarsFactory.Reports.ReportManagers.Contracts;

namespace CarsFactory.Reports.ReportManagers.Abstract
{
    /// <summary>
    /// Provides methods for the management and generation of reports.
    /// </summary>
    public abstract class ReportManager : IReportManager
    {
        private readonly IFileDirectoryProvider fileDirectoryProvider;
        private readonly IDocumentAdapterFactory documentAdapterFactory;

        protected ReportManager(IFileDirectoryProvider fileDirectoryProvider, IDocumentAdapterFactory documentAdapterFactory)
        {
            if (fileDirectoryProvider == null)
            {
                throw new ArgumentNullException(nameof(fileDirectoryProvider));
            }

            if (documentAdapterFactory == null)
            {
                throw new ArgumentNullException(nameof(documentAdapterFactory));
            }

            this.documentAdapterFactory = documentAdapterFactory;
            this.fileDirectoryProvider = fileDirectoryProvider;
        }

        protected IDocumentAdapterFactory DocumentAdapterAdapterFactory
        {
            get { return this.documentAdapterFactory; }
        }

        protected ICollection<IReport> Reports { get; private set; }

        /// <summary>
        /// Generates each of the contained reports to the specified directory.
        /// </summary>
        /// <param name="directoryLocation">The directory to save the reports to.</param>
        /// <param name="dbContext">The datasource.</param>
        public void GenerateReports(string directoryLocation, ICarsFactoryDbContext dbContext)
        {
            if (this.Reports == null || this.Reports.Count == 0)
            {
                throw new InvalidOperationException("No reports to generate! You must add some reports first.");
            }

            if (!this.fileDirectoryProvider.DirectoryExists(directoryLocation))
            {
                this.fileDirectoryProvider.CreateDirectory(directoryLocation);
            }

            foreach (IReport report in this.Reports)
            {
                var fileNameAndPath =
                    $"{directoryLocation}{report.GetType().Name}-{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
                var fileWithExtension = this.AppendFileExtension(fileNameAndPath);

                var fileStream = this.fileDirectoryProvider.CreateFileStream(fileWithExtension);

                var document = this.CreateDocument(fileWithExtension, fileStream);

                report.Generate(document, dbContext);
            }
        }

        /// <summary>
        /// Adds an IReport to be generated.
        /// </summary>
        /// <param name="report">IReport to be added.</param>
        public void Add(IReport report)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report));
            }

            if (this.Reports == null)
            {
                this.Reports = new List<IReport>();
            }

            this.Reports.Add(report);
        }

        /// <summary>
        /// Adds a collection of IReports to be generated.
        /// </summary>
        /// <param name="reports">IReports to be added.</param>
        public void Add(IEnumerable<IReport> reports)
        {
            if (reports == null)
            {
                throw new ArgumentNullException(nameof(reports));
            }

            foreach (var report in reports)
            {
                this.Add(report);
            }
        }

        protected abstract IDocumentAdapter CreateDocument(string fileName, Stream stream);

        protected abstract string AppendFileExtension(string fileName);
    }
}
