using AutoRent.DBContext;
using AutoRent.Migrations;
using AutoRent.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent
{
    class Program
    {
        
        static void Main(string[] args)
        {
            using (var context = new RentACarContext())
            {
                
                var malinov = new Office() { City = "Sofia", Address = "Malinov 31" };
                var druzhba = new Office() { City = "Sofia", Address = "Druzhba 2" };
                var Triaditza = new Office() { City = "Plovdiv", Address = "Goce Delchev 32" };
                var varna = new Office() { City = "Varna", Address = "Aleko 30" };
                var varna2 = new Office() { City = "Varna", Address = "Konstantinov 50" };


                var honda = new Car() { Make = "Honda", Model = "Civic", Type = "Sedan", IsAvailable = true, Price = 10.5m, Office = malinov };
                var bmw = new Car() { Make = "BMW", Model = "3", Type = "Sedan", IsAvailable = true, Price = 20.5m, Office = druzhba };
                var bmwX5 = new Car() { Make = "BMW", Model = "X5", Type = "Jeep", IsAvailable = true, Price = 25.5m, Office = Triaditza };

                context.Offices.Add(malinov);
                context.Offices.Add(druzhba);
                context.Offices.Add(Triaditza);
                context.Offices.Add(varna);
                context.Offices.Add(varna2);

                context.Cars.Add(honda);
                context.Cars.Add(bmw);
                context.Cars.Add(bmwX5);

                var joro = new User() { FirstName = "Joro", FamilyName = "Petkov", PIN = "8805684234", Status = Enum.UserStatus.VIP,
                    DrivingLicenseNumber = "7345223423", PhoneNumber = "0885435264" };
                var marto = new User()
                {
                    FirstName = "Marto",
                    FamilyName = "Kamburov",
                    PIN = "9845645635",
                    Status = Enum.UserStatus.New,
                    DrivingLicenseNumber = "7258749875",
                    PhoneNumber = "0885425464"
                };
                var silvio = new User()
                {
                    FirstName = "Silvio",
                    FamilyName = "Prandi",
                    PIN = "9252347345",
                    Status = Enum.UserStatus.Loyal,
                    DrivingLicenseNumber = "7239842305",
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
