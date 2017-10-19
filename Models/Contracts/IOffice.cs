using System.Collections.Generic;

namespace Models.Contracts
{
    public interface IOffice
    {
        string City { get; set; }

        string Address { get; set; }

        ICollection<Car> Cars { get; set; }
    }
}
