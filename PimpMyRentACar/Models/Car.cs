
using AutoRent.Enum;
using AutoRent.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoRent
{
    public class Car
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
        public bool IsAvailable { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? OfficeId { get; set; }

        public virtual Office Office { get; set; }

        public ICollection<UserStatus> UserStatus { get; set; }

        public virtual ICollection<Order> Orders { get; set; } //for the ordersHistory


    }
}
