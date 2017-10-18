using Models;
using System.Data.Entity;

namespace Data.Context
{
    public interface IAutoRentContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<Car> Cars { get; set; }

        IDbSet<Office> Offices { get; set; }

        int SaveChanges();
    }
}