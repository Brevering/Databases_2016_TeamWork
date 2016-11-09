using System;
using System.Linq;

using CarsFactory.Data.Contracts;
using CarsFactory.Models.Enums;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.Reports.Contracts;

namespace CarsFactory.Reports.Reports
{
    public class DealerSalesReportForLastQuarter : IReport
    {
        /// <summary>
        /// Generates a new DealerSalesReportForLastQuarter.
        /// </summary>
        public void Generate(IDocumentAdapter document, ICarsFactoryDbContext dbContext)
        {
            var pastDate = DateTime.Now.AddMonths(-3);
            Console.WriteLine(dbContext.Orders.First().TotalPrice);

            var dealerData = (from dealer in dbContext.Dealers
                              let cars = dealer.Cars.Where(car => car.OrderId != null
                                                                  && car.Order.OrderStatus == OrderStatus.Closed
                                                                  && car.Order.Date > pastDate)
                                               .Select(c => new
                                                            {
                                                                Model = c.Model.Manufacturer.Name + " " + c.Model.Name,
                                                                Year = c.Year.Year,
                                                                Price = c.Price,
                                                                OrderDate = c.Order.Date,
                                                                OrderId = c.OrderId
                                                            })
                              select new
                                     {
                                         Cars = cars.ToList(),
                                         Name = dealer.Name,
                                         Town = dealer.Town.Name,
                                     }
                ).OrderByDescending(x => x.Cars.Count)
                 .ToList();

            document.AddMetadata()
                    .AddHeader($"Dealer sales report for the last three months. Generated on {DateTime.Now}");

            foreach (var dealer in dealerData)
            {
                var deal = new { Dealer = dealer.Name + ", " + dealer.Town };
                var dealerTableData = new[] { deal }.ToList();
                document.AddTabularData(dealerTableData);

                if (dealer.Cars.Count > 0)
                {
                    document.AddTabularData(dealer.Cars);
                }

                var totalsTableData = new { TotalRevenue = dealer.Cars.Sum(c => c.Price) };
                var totals = new[] { totalsTableData }.ToList();
                document.AddTabularData(totals);
                document.AddHeader(string.Empty);
            }

            document.Save();
        }
    }
}
