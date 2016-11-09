using System.Data.Entity;

using CarsFactory.Data.Contracts;
using CarsFactory.Data.Migrations;
using CarsFactory.Models;

namespace CarsFactory.Data
{
    public class CarsFactoryDbContext : DbContext, ICarsFactoryDbContext
    {
        public CarsFactoryDbContext()
            : base("CarsFactory")
        {
           var migrationStrategy = new MigrateDatabaseToLatestVersion<CarsFactoryDbContext, Configuration>();
           Database.SetInitializer(migrationStrategy);
        }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<Dealer> Dealers { get; set; }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }

        public virtual IDbSet<Model> Models { get; set; }

        public virtual IDbSet<Platform> Platforms { get; set; }

        public virtual IDbSet<Engine> Engines { get; set; }

        public virtual IDbSet<Order> Orders { get; set; }

        public virtual IDbSet<Town> Towns { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
