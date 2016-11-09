using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using CarsFactory.Data.Contracts;
using CarsFactory.Models;

namespace CarsFactory.Data
{
    /// <summary>
    /// Microsoft's SQL repository
    /// </summary>
    public class MsSqlRepository : IMsSqlRepository
    {
        public async Task CreateDb()
        {
            using (var ctx = new CarsFactoryDbContext())
            {
                //await ctx.Cars.ToListAsync();
                await ctx.SaveChangesAsync();
            }
        }

        public void ExtractTowns(ICollection<Town> towns, ICarsFactoryDbContext ctx)
        {
            try
            {
                using (ctx = new CarsFactoryDbContext())
                {
                    foreach (var town in towns)
                    {
                        if (!ctx.Towns.Any(t => t.Name == town.Name))
                        {
                            ctx.Towns.Add(town);
                        }
                    }

                    ctx.SaveChanges();
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExtractPlatforms(ICollection<Platform> platforms, ICarsFactoryDbContext ctx)
        {
            try
            {
                using (ctx = new CarsFactoryDbContext())
                {
                    foreach (var platform in platforms)
                    {
                        if (!ctx.Platforms.Any(p => p.Id == platform.Id))
                        {
                            ctx.Platforms.Add(platform);
                        }
                    }

                    ctx.SaveChanges();
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExtractOrders(ICollection<Order> orders, ICarsFactoryDbContext ctx)
        {
            try
            {
                using (ctx = new CarsFactoryDbContext())
                {
                    foreach (var order in orders)
                    {
                        if (!ctx.Orders.Any(p => p.Id == order.Id))
                        {
                            ctx.Orders.Add(order);
                        }
                    }

                    ctx.SaveChanges();
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExtractManufacturers(ICollection<Manufacturer> manufacturers, ICarsFactoryDbContext ctx)
        {
            try
            {
                using (ctx = new CarsFactoryDbContext())
                {
                    foreach (var manufacturer in manufacturers)
                    {
                        if (!ctx.Manufacturers.Any(e => e.Id == manufacturer.Id))
                        {
                            ctx.Manufacturers.Add(manufacturer);
                        }
                    }

                    ctx.SaveChanges();
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExtractEngines(ICollection<Engine> engines, ICarsFactoryDbContext ctx)
        {
            try
            {
                using (ctx = new CarsFactoryDbContext())
                {
                    foreach (var engine in engines)
                    {
                        if (!ctx.Engines.Any(e => e.Id == engine.Id))
                        {
                            ctx.Engines.Add(engine);
                        }
                    }

                    ctx.SaveChanges();
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExtractModels(ICollection<Model> models, ICarsFactoryDbContext ctx)
        {
            try
            {
                using (ctx = new CarsFactoryDbContext())
                {
                    foreach (var model in models)
                    {
                        if (!ctx.Models.Any(m => m.Id == model.Id))
                        {
                            ctx.Models.Add(model);
                        }
                    }

                    ctx.SaveChanges();
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExtractDealers(ICollection<Dealer> dealers, ICarsFactoryDbContext ctx)
        {
            try
            {
                using (ctx = new CarsFactoryDbContext())
                {
                    foreach (var dealer in dealers)
                    {
                        if (!ctx.Dealers.Any(m => m.Id == dealer.Id))
                        {
                            ctx.Dealers.Add(dealer);
                        }
                    }

                    ctx.SaveChanges();
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExtractCars(ICollection<Car> cars, ICarsFactoryDbContext ctx)
        {
            try
            {
                using (ctx = new CarsFactoryDbContext())
                {
                    foreach (var car in cars)
                    {
                        if (!ctx.Cars.Any(c => c.Id == car.Id))
                        {
                            ctx.Cars.Add(car);
                        }
                    }

                    ctx.SaveChanges();
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
