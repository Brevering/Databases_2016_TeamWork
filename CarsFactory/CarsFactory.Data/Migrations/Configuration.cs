using System.Data.Entity.Migrations;

namespace CarsFactory.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CarsFactoryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarsFactoryDbContext context)
        {

        }
    }
}
