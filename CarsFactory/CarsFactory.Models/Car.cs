using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsFactory.Models
{
    public class Car
    {
        private const string PriceCannotBeNegativeErrorMessage = "Price cannot be negative";
        private const string ObjectCannotBeNull = "{0} cannot be null";
        private const string DealerIdNegativeOrZeroErrorMessage = "DealerId must be positive number";
        private decimal price;
        private Order order;
        private Dealer dealer;
        private Model model;
        private int dealerId;

        public int Id { get; set; }

        public int ModelId { get; set; }

        public virtual Model Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format(ObjectCannotBeNull, "Model"));
                }

                this.model = value;
            }
        }

        public int DealerId
        {
            get
            {
                return this.dealerId;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(DealerIdNegativeOrZeroErrorMessage);
                }

                this.dealerId = value;
            }
        }

        public virtual Dealer Dealer
        {
            get
            {
                return this.dealer;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format(ObjectCannotBeNull, "Dealer"));
                }

                this.dealer = value;
            }
        }

        public DateTime Year { get; set; }

        public Nullable<int> OrderId { get; set; }

        public Order Order
        {
            get
            {
                return this.order;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format(ObjectCannotBeNull, "Order"));
                }

                this.order = value;
            }
        }

        [Required]
        [Column(TypeName = "Money")]
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(PriceCannotBeNegativeErrorMessage);
                }

                this.price = value;
            }
        }
    }
}
