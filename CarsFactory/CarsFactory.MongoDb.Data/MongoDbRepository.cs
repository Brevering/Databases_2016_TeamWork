using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CarsFactory.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using CarsFactory.MongoDb.Data.Contracts;

namespace CarsFactory.MongoDb.Data
{
    public class MongoDbRepository : IMongoDbRepository
    {
        private const string ConnectionString = "mongodb://pesho:gosho@ds033297.mlab.com:33297/factory";
        private static readonly MongoClient Client = new MongoClient(ConnectionString);
        private static readonly IMongoDatabase Database = Client.GetDatabase("factory");

        private static readonly IMongoCollection<BsonDocument> CarsCollection = MbDatabase.GetCollection<BsonDocument>("Cars");
        private static readonly IMongoCollection<BsonDocument> DealersCollection = MbDatabase.GetCollection<BsonDocument>("Dealers");
        private static readonly IMongoCollection<BsonDocument> EnginesCollection = MbDatabase.GetCollection<BsonDocument>("Engines");
        private static readonly IMongoCollection<BsonDocument> ManufacturersCollection = MbDatabase.GetCollection<BsonDocument>("Manufacturers");
        private static readonly IMongoCollection<BsonDocument> ModelsCollection = MbDatabase.GetCollection<BsonDocument>("Models");
        private static readonly IMongoCollection<BsonDocument> OrdersCollection = MbDatabase.GetCollection<BsonDocument>("Orders");
        private static readonly IMongoCollection<BsonDocument> PlatformsCollection = MbDatabase.GetCollection<BsonDocument>("Platforms");
        private static readonly IMongoCollection<BsonDocument> TownsCollection = MbDatabase.GetCollection<BsonDocument>("Towns");

        public static IMongoDatabase MbDatabase
        {
            get
            {
                return Database;
            }
        }

        public async Task<IList<Car>> GetCarsData()
        {
            var cars = (await CarsCollection.Find(new BsonDocument()).ToListAsync())
                .Select(bs => BsonSerializer.Deserialize<Car>(bs)).ToList();

            return cars;
        }

        public async Task<IList<Manufacturer>> GetManufacturersData()
        {
            var manufacturers = (await ManufacturersCollection.Find(new BsonDocument()).ToListAsync())
                .Select(bs => BsonSerializer.Deserialize<Manufacturer>(bs)).ToList();

            return manufacturers;
        }

        public async Task<IList<Dealer>> GetDealersData()
        {
            var dealers = (await DealersCollection.Find(new BsonDocument()).ToListAsync())
                .Select(bs => BsonSerializer.Deserialize<Dealer>(bs)).ToList();

            return dealers;
        }

        public async Task<IList<Engine>> GetEnginesData()
        {
            var engines = (await EnginesCollection.Find(new BsonDocument()).ToListAsync())
                .Select(bs => BsonSerializer.Deserialize<Engine>(bs)).ToList();

            return engines;
        }

        public async Task<IList<Model>> GetModelsData()
        {
            var models = (await ModelsCollection.Find(new BsonDocument()).ToListAsync())
                .Select(bs => BsonSerializer.Deserialize<Model>(bs)).ToList();

            return models;
        }

        public async Task<IList<Order>> GetOrdersData()
        {
            var orders = (await OrdersCollection.Find(new BsonDocument()).ToListAsync())
                .Select(bs => BsonSerializer.Deserialize<Order>(bs)).ToList();

            return orders;
        }

        public async Task<IList<Platform>> GetPlatformsData()
        {
            var platforms = (await PlatformsCollection.Find(new BsonDocument()).ToListAsync())
                .Select(bs => BsonSerializer.Deserialize<Platform>(bs)).ToList();

            return platforms;
        }

        public async Task<IList<Town>> GetTownsData()
        {
            var towns = (await TownsCollection.Find(new BsonDocument()).ToListAsync())
                .Select(bs => BsonSerializer.Deserialize<Town>(bs)).ToList();

            return towns;
        }
    }
}
