using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsFactory.Models
{
    public class Dealer
    {
        private const int NameMaxLength = 50;
        private const string MaxStringLengthErrorMessage = "Name length cannot be greater then {0}";
        private const string TownNegativeOrZeroErrorMessage = "Town must be positive number";
        private const string TownCannotBeNullErrorMessage = "Town cannot be null";
        private ICollection<Car> cars;
        private string name;
        private int townId;
        private Town town;

        public Dealer()
        {
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length > NameMaxLength)
                {
                    throw new ArgumentOutOfRangeException(string.Format(MaxStringLengthErrorMessage, NameMaxLength));
                }

                this.name = value;
            }
        }

        public int TownId
        {
            get
            {
                return this.townId;
            }
                
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(TownNegativeOrZeroErrorMessage);
                }

                this.townId = value;
            }
        }

        public Town Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(TownCannotBeNullErrorMessage);
                }

                this.town = value;
            }
        }

        public virtual ICollection<Car> Cars
        {
            get
            {
                return this.cars;
            }

            set
            {
                this.cars = value;
            }
        }
    }
}