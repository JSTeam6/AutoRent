using Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Order : IOrder
    {
        public Order()
        {
        }

        public int Id { get; set; }

        public int? CarId { get; set; }

        [Required]
        public virtual Car Car { get; set; }

        public int? UserId { get; set; }

        [Required]
        public virtual User User { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public DateTime? DepartureDate { get; set; }

        public DateTime? ArrivalDate { get; set; }
    }
}
