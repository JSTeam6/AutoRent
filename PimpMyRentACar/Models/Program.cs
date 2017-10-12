using PimpMyRentACar.DBContext;
using PimpMyRentACar.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimpMyRentACar
{
    class Program
    {
        
        static void Main(string[] args)
        {

            using (var db = new RentACarContext())
            {
                db.SaveChanges();
                //var user = new User() { FirstName = "Joro", FamilyName = "Petkov" };
                //user.PhoneNumber = "304975094730496";
                //user.PIN = "0593450934";
                //user.Status = "VIP";
                //user.DrivingLicenseNumber = "0903753863";
                //db.Users.Add(user);
                //db.SaveChanges();

                //  var query = from b in db.Us5ers
                //              select b;

                //  foreach (var u in query)
                //  {
                //      Console.WriteLine(u.FirstName + u.FamilyName);
                //  }

                //Console.WriteLine(db.Users.Count());


                //var city = new City { CityName = name };
                //db.Cities.Add(city);
                //db.SaveChanges();

                //// Display all Blogs from the database 
                //var query = from b in db.Cities
                //            orderby b.CityName
                //            select b;

                //Console.WriteLine("All blogs in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.CityName);
                //}

                //Console.WriteLine("Press any key to exit...");
                //Console.ReadKey();
            }
        }
    }
}
