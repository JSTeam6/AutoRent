using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoRent.Models;
using AutoRent.Migrations;

namespace AutoRent.DBContext
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
