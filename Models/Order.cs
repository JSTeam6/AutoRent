<<<<<<< HEAD
﻿using System;
=======
﻿using Models.Contracts;
using System;
>>>>>>> z
using System.ComponentModel.DataAnnotations;

namespace Models
{
<<<<<<< HEAD
    public class Order
=======
    public class Order : IOrder
>>>>>>> z
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
