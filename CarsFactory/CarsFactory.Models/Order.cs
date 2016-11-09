using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CarsFactory.Models.Enums;

namespace CarsFactory.Models
{
    public class Order
    {
        private ICollection<Car> cars;

        public Order()
        {
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [DefaultValue(1)]
        public OrderStatus OrderStatus { get; set; }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

        [NotMapped]
        public decimal TotalPrice
        {
            get { return this.Cars.ToList().Sum(x => x.Price); }
        }
    }
}
