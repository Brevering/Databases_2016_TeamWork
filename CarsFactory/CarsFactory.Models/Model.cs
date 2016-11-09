using System;
using System.ComponentModel.DataAnnotations;

namespace CarsFactory.Models
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime? Year { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public int PlatformId { get; set; }

        public virtual Platform Platform { get; set; }

        public int EngineId { get; set; }

        public virtual Engine Engine { get; set; }
    }
}
