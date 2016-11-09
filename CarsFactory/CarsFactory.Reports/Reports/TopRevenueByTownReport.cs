using System;
using System.Linq;

using CarsFactory.Data.Contracts;
using CarsFactory.Models.Enums;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.Reports.Contracts;

namespace CarsFactory.Reports.Reports
{
    public class TopRevenueByTownReport : IReport
    {
        /// <summary>
        /// Generates a new TopRevenueByTownReport.
        /// </summary>
        public void Generate(IDocumentAdapter document, ICarsFactoryDbContext dbContext)
        {
            var topTowns = (from car in
                dbContext.Cars
                         .Where(car => car.OrderId != null && car.Order.OrderStatus == OrderStatus.Closed)
                            group car by car.Dealer.Town.Name
                            into g
                            orderby g.Count() descending
                            select new
                                   {
                                       Town = g.Key,
                                       OrderCount = g.Count()
                                   })
                .ToList();

            document.AddMetadata()
                    .AddHeader($"Most orders by town. Generated on {DateTime.Now}")
                    .AddTabularData(topTowns)
                    .Save();
        }
    }
}
