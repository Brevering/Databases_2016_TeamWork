using System;
using CarsFactory.Models.Enums;

namespace CarsFactory.Models
{
    public class Engine
    {
        private const string HorsePowerNegativeOrZeroErrorMessage = "Horse power must be positive number";
        private int horsePower;

        public int Id { get; set; }

        public FuelType Fuel { get; set; }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }            
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(HorsePowerNegativeOrZeroErrorMessage);
                }

                this.horsePower = value;
            }
        }
    }
}
