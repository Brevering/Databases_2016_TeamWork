using CarsFactory.Models.Enums;

namespace CarsFactory.Models
{
    public class Platform
    {
        public int Id { get; set; }

        public PlatformType PlatformType { get; set; }

        public int NumberOfDoors { get; set; }
    }
}