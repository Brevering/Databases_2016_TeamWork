using System.Threading.Tasks;

using CarsFactory.Data.Contracts;
using CarsFactory.MongoDb.Data.Contracts;
/// <summary>
/// 
/// </summary>
namespace CarsFactory.Reports.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGenerateDataFromMongoDb
    {
        Task SaveAllMongoData(IMongoDbRepository repo, IMsSqlRepository mssqlRepo, ICarsFactoryDbContext ctx);
    }
}
