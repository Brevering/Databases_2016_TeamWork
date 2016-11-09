using System.Collections.Generic;
using System.Linq;

using CarsFactory.DtoModels;

namespace CarsFactory.SQLite.Data
{
    public class SqLiteRepository
    {
        public IList<TownInfoDto> GetTownsData()
        {
            var ctx = new TownInfoEntities();

            var towns = ctx.TownInfoes.Select(t => new TownInfoDto()
            {
                Name = t.Name
            }).ToList();

            return towns;
        }
    }
}
