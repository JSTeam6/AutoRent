
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Order
    {
        public Order()
        {
        }

        public int Id { get; set; }

        [Required]
        public int? CarId { get; set; }

        public virtual Car Car { get; set; }

        public int? UserId { get; set; }

        [Required]
        public virtual User User { get; set; }
        
        public DateTime? DepartureDate { get; set; }

        public DateTime? ArrivalDate { get; set; }

    }
}
