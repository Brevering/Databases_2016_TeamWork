using System;
using System.Linq;

using CarsFactory.Data.Contracts;
using CarsFactory.Models.Enums;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.Reports.Contracts;

namespace CarsFactory.Reports.Reports
{
    public class TopSellingManufacturersReport : IReport
    {
        /// <summary>
        /// Generates a new TopSellingManufacturersReport.
        /// </summary>
        public void Generate(IDocumentAdapter document, ICarsFactoryDbContext dbContext)
        {
            var topManufacturers =
                (from car in
                    dbContext.Cars.Where(car => car.OrderId != null && car.Order.OrderStatus == OrderStatus.Closed)
                 group car by car.Model.Manufacturer.Name
                 into g
                 orderby g.Count() descending
                 select new
                        {
                            Model = g.Key,
                            OrderCount = g.Count()
                        })
                    .ToList();

            document.AddMetadata()
                    .AddHeader($"Top selling manufacturers of all time. Generated on {DateTime.Now}")
                    .AddTabularData(topManufacturers)
                    .Save();
        }
    }
}
