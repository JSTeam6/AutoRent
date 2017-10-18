using Models.Contracts;
using Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Car : ICar
    {
        public Car()
        {
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Make { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public int? OfficeId { get; set; }

        public virtual Office Office { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
