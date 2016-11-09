using CarsFactory.Data.Contracts;

namespace CarsFactory.Reports.Contracts
{
    public interface IGenerateDataFromZipFiles
    {
        void SaveAllDataFromZip(IMsSqlRepository repo, ICarsFactoryDbContext ctx, string filePath);
    }
}
