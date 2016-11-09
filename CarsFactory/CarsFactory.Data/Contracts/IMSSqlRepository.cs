using CarsFactory.Models;
using System.Collections.Generic;

namespace CarsFactory.Data.Contracts
{
    public interface IMsSqlRepository
    {
        void ExtractTowns(ICollection<Town> towns, ICarsFactoryDbContext ctx);

        void ExtractPlatforms(ICollection<Platform> platforms, ICarsFactoryDbContext ctx);

        void ExtractOrders(ICollection<Order> orders, ICarsFactoryDbContext ctx);

        void ExtractManufacturers(ICollection<Manufacturer> manufacturers, ICarsFactoryDbContext ctx);

        void ExtractEngines(ICollection<Engine> engines, ICarsFactoryDbContext ctx);

        void ExtractModels(ICollection<Model> models, ICarsFactoryDbContext ctx);

        void ExtractDealers(ICollection<Dealer> dealers, ICarsFactoryDbContext ctx);

        void ExtractCars(ICollection<Car> cars, ICarsFactoryDbContext ctx);
    }
}
