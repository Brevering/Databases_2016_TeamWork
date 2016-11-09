using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsFactory.Models
{
    public class Town
    {
        private ICollection<Dealer> dealers;

        public Town()
        {
            this.dealers = new HashSet<Dealer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Dealer> Dealers
        {
            get { return this.dealers; }
            set { this.dealers = value; }
        }
    }
}
