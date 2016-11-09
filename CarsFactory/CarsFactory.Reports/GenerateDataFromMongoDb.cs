using System;
using System.Linq;
using System.Threading.Tasks;

using CarsFactory.Data;
using CarsFactory.Data.Contracts;
using CarsFactory.MongoDb.Data.Contracts;
using CarsFactory.Reports.Contracts;

namespace CarsFactory.Reports
{
    public class GenerateDataFromMongoDb : IGenerateDataFromMongoDb
    {
        public async Task SaveAllMongoData(IMongoDbRepository repo, IMsSqlRepository mssqlRepo, ICarsFactoryDbContext ctx)
        {
            var towns = (await repo.GetTownsData()).ToList();
            var platforms = (await repo.GetPlatformsData()).ToList();
            var orders = (await repo.GetOrdersData()).ToList();
            var models = (await repo.GetModelsData()).ToList();
            var manufacturers = (await repo.GetManufacturersData()).ToList();
            var engines = (await repo.GetEnginesData()).ToList();
            var dealers = (await repo.GetDealersData()).ToList();
            var cars = (await repo.GetCarsData()).ToList();


            using (ctx = new CarsFactoryDbContext())
            {
                mssqlRepo.ExtractTowns(towns, ctx);
                mssqlRepo.ExtractPlatforms(platforms, ctx);
                mssqlRepo.ExtractOrders(orders, ctx);
                mssqlRepo.ExtractManufacturers(manufacturers, ctx);
                mssqlRepo.ExtractEngines(engines, ctx);
                mssqlRepo.ExtractModels(models, ctx);
                mssqlRepo.ExtractCars(cars, ctx);
                mssqlRepo.ExtractDealers(dealers, ctx);
                await ctx.SaveChangesAsync();
            }

            Console.WriteLine(cars.Count);
            Console.WriteLine(models.Count);
            Console.WriteLine(manufacturers.Count);
            Console.WriteLine(orders.Count);
            Console.WriteLine(platforms.Count);
            Console.WriteLine(engines.Count);
            Console.WriteLine(dealers.Count);
            Console.WriteLine(towns.Count);
        }
    }
}
