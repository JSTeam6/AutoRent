
using PimpMyRentACar.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PimpMyRentACar
{
    public class Car
    {
       
        public Car()
        {
            //this.UserStatus = new HashSet<string>();
            //this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Type { get; set; } //FK

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public decimal Price { get; set; }

        //public virtual Office Office { get; set; }

        //public int? OfficeId { get; set; }

        //public ICollection<string> UserStatus { get; set; }

        public virtual Order Order { get; set; }
        
        //public virtual ICollection<Order> Orders { get; set; }
            //we use it to track the order history of the vehicle

    }
}
