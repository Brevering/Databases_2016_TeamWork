using System.Collections.Generic;
using System.Threading.Tasks;

using CarsFactory.Models;

namespace CarsFactory.MongoDb.Data.Contracts
{
    public interface IMongoDbRepository
    {
        Task<IList<Car>> GetCarsData();

        Task<IList<Manufacturer>> GetManufacturersData();

        Task<IList<Dealer>> GetDealersData();

        Task<IList<Platform>> GetPlatformsData();

        Task<IList<Town>> GetTownsData();

        Task<IList<Model>> GetModelsData();

        Task<IList<Engine>> GetEnginesData();

        Task<IList<Order>> GetOrdersData();
    }
}
