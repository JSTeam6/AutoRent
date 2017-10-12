
using PimpMyRentACar.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PimpMyRentACar
{
    public class Car
    {
        public Car()
        {
            this.UserStatus = new HashSet<string>();
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public virtual Office Office { get; set; } //it could be at only one location at a certain time

        public int? OfficeId { get; set; }

        [Required]
        public string Type { get; set; } //FK

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<string> UserStatus { get; set; }

        public virtual ICollection<Order> Orders { get; set; } //we use it to track the order history of the vehicle

    }
}
