using Data.Migrations;
using Models;
using System.Data.Entity;

namespace Data.Context
{
    public class RentACarContext : DbContext
    {
        public RentACarContext() : base("name=RentACarSystem")
        {
            var strategy = new MigrateDatabaseToLatestVersion<RentACarContext, Configuration>();
            Database.SetInitializer(strategy);
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Office> Offices { get; set; }
    }
}
