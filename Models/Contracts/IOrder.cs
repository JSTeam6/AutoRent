using System;

namespace Models.Contracts
{
    public interface IOrder
    {
        int Id { get; set; }

        int? CarId { get; set; }

        Car Car { get; set; }

        int? UserId { get; set; }

        User User { get; set; }

        DateTime? PurchaseDate { get; set; }

        DateTime? DepartureDate { get; set; }

        DateTime? ArrivalDate { get; set; }
    }
}
