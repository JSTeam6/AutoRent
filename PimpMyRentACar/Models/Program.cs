using PimpMyRentACar.DBContext;
using PimpMyRentACar.Migrations;
using PimpMyRentACar.Models;
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
            using (var context = new RentACarContext())
            {


                var malinov = new Office() { City = "Sofia", Address = "Malinov 31" };
                var druzhba = new Office() { City = "Sofia", Address = "Druzhba 2" };
                var Triaditza = new Office() { City = "Sofia", Address = "Goce Delchev 32" };

                var honda = new Car() { Make = "Honda", Model = "Civic", Type = "Sedan", IsAvailable = true, Price = 10.5m, Office = malinov };
                var bmw = new Car() { Make = "BMW", Model = "3", Type = "Sedan", IsAvailable = true, Price = 20.5m, Office = druzhba };
                var bmwX5 = new Car() { Make = "BMW", Model = "X5", Type = "Jeep", IsAvailable = true, Price = 25.5m, Office = Triaditza };

                context.Offices.Add(malinov);
                context.Offices.Add(druzhba);
                context.Offices.Add(Triaditza);

                context.Cars.Add(honda);
                context.Cars.Add(bmw);
                context.Cars.Add(bmwX5);

                var joro = new User() { FirstName = "Joro", FamilyName = "Petkov", PIN = "8805684234", Status = "VIP",
                    DrivingLicenseNumber = "07345223423", PhoneNumber = "0885435264" };
                var marto = new User()
                {
                    FirstName = "Marto",
                    FamilyName = "Kamburov",
                    PIN = "9845645635",
                    Status = "Ban",
                    DrivingLicenseNumber = "72587349875",
                    PhoneNumber = "0885425464"
                };
                var silvio = new User()
                {
                    FirstName = "Silvio",
                    FamilyName = "Prandi",
                    PIN = "09252347345",
                    Status = "Loyal",
                    DrivingLicenseNumber = "0723842305",
                    PhoneNumber = "0885468264"
                };

                context.Users.Add(joro);
                context.Users.Add(marto);
                context.Users.Add(silvio);
                
                context.SaveChanges();

                var date = DateTime.Now;
                var order = new Order()
                {
                    Car = bmwX5,
                    User = marto,
                    PurchaseDate = date,
                    DepartureDate = date.AddDays(2),
                    ArrivalDate = date.AddDays(4)
                    
                };

                context.Orders.Add(order);
                context.Orders.Add(new Order() { Car = honda, User = joro });
                
                context.SaveChanges();
                
            }
            
        }
    }
}
