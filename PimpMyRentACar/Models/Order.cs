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
        
        public int Id { get; set; }

        [Required]
        public virtual Car Car { get; set; } //lazy loading

        public int? CarId { get; set; }

        public DateTime? PurchaseDate {get; set; }

        public DateTime? DepartureDate { get; set; }

        public DateTime? ArrivalDate { get; set; }

        [Required]
        public virtual User User { get; set; }

        public int? UserId { get; set; }
        
    }
}
