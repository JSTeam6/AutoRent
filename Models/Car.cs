using Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Car
    {
        public Car()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The {0} must be maximum 20 characters long")]
        public string Make { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The {0} must be maximum 20 characters long")]
        public string Model { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The {0} must be maximum 20 characters long")]
        public string Type { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime? AvailableFrom { get; set; }

        public int? OfficeId { get; set; }

        public virtual Office Office { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
