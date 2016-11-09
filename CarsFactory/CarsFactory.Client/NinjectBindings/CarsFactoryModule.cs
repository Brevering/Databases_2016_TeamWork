using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using CarsFactory.Reports;
using CarsFactory.Reports.Documents;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.ReportManagers;
using CarsFactory.Reports.ReportManagers.Abstract;
using CarsFactory.Reports.ReportManagers.Contracts;

using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace CarsFactory.Client.NinjectBindings
{
    public class CarsFactoryModule : NinjectModule
    {
        /// <summary>Loads the module into the kernel.</summary>
        public override void Load()
        {
            this.Kernel.Bind(x =>
                             {
                                 x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                                  .SelectAllClasses()
                                  .BindDefaultInterface();
                             });
            this.Bind<IDocumentAdapterFactory>().ToFactory();

            this.Bind<IDocumentAdapter>().To<PdfDocumentAdapter>().Named(typeof(PdfDocumentAdapter).Name);

            this.Rebind<IReportService>().To<ReportService>().InSingletonScope();

            this.Bind<IReportManager>().To<PdfReportManager>().Named(typeof(PdfReportManager).Name);

            this.Bind<IEnumerable<IReportManager>>()
                .ToMethod(context =>
                          {
                              var assembly = typeof(IReportManager).Assembly;

                              var reportManagerTypes = assembly.GetTypes()
                                                               .Where(t => t.IsSubclassOf(typeof(ReportManager)));
                              var reportManagers =
                                  reportManagerTypes.Select(reportManagerType =>
                                                                context.Kernel.Get<IReportManager>(reportManagerType.Name))
                                                    .ToList();
                              return reportManagers;
                          })
                .WhenInjectedExactlyInto<IReportService>();
        }
    }
}
