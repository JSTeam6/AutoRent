using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimpMyRentACar
{
    public class Order
    {
        public Order()
        {

        }

        public string Id { get; set; } //we use this one to relate the order to
        //either an existing user or a new one

        public  Car Car { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        public virtual User User { get; set; } //naviagtional property

        public int? UserId { get; set; }
        //each and every col that points at another col is to be set as virtual

        //public string UserID { get; set; } //FK
    }
}
