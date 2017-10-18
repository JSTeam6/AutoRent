using Data.Migrations;
using Models;
using System.Data.Entity;

namespace Data.Context
{
    public class AutoRentContext : DbContext, IAutoRentContext
    {
        public AutoRentContext() : base("name=AutoRent")
        {
            var strategy = new MigrateDatabaseToLatestVersion<AutoRentContext, Configuration>();
            Database.SetInitializer(strategy);
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Office> Offices { get; set; }
    }
}
