using System;
using System.Linq;

using CarsFactory.Data.Contracts;
using CarsFactory.Models.Enums;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.Reports.Contracts;

namespace CarsFactory.Reports.Reports
{
    public class TopTotalRevenueByDealerReport : IReport
    {
        /// <summary>
        /// Generates a new TopTotalRevenueByDealerReport.
        /// </summary>
        public void Generate(IDocumentAdapter document, ICarsFactoryDbContext dbContext)
        {
            var totalRevenueByDealers = (from dealer in dbContext.Dealers
                                         let totalRevenue =
                                             (decimal?)dealer.Cars.Where(
                                                                         y =>
                                                                             y.OrderId != null &&
                                                                             y.Order.OrderStatus == OrderStatus.Closed)
                                                             .Sum(x => x.Price)
                                         let town = dealer.Town.Name
                                         let orderCount =
                                             dealer.Cars.Count(
                                                               y =>
                                                                   y.OrderId != null &&
                                                                   y.Order.OrderStatus == OrderStatus.Closed)
                                         orderby totalRevenue descending
                                         select new
                                                {
                                                    Dealer = dealer.Name,
                                                    TotalRevenue = totalRevenue,
                                                    Town = town,
                                                    TotalOrders = orderCount
                                                })
                .Take(10)
                .ToList();

            document.AddMetadata()
                    .AddHeader($"Top 10 total revenue by dealer for all time. Generated on {DateTime.Now}")
                    .AddTabularData(totalRevenueByDealers)
                    .Save();
        }
    }
}
