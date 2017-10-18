using System.Collections.Generic;

namespace Models.Contracts
{
    public interface ICar
    {
        string Make { get; set; }

        string Model { get; set; }

        string Type { get; set; }

        bool IsAvailable { get; set; }

        decimal Price { get; set; }

        int? OfficeId { get; set; }

        Office Office { get; set; }

        ICollection<Order> Orders { get; set; }
    }
}
