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
                var sofia = new City() { CityName = "Sofia" };
                var burgas = new City() { CityName = "Bourgas" };
                var varna = new City() { CityName = "Varna" };
                var plovdiv = new City() { CityName = "Plovdiv" };


                var malinov = new Office() { City = sofia, Address = "Malinov 31" };
                var druzhba = new Office() { City = sofia, Address = "Druzhba 2" };
                var Triaditza = new Office() { City = sofia, Address = "Goce Delchev 32" };

                var honda = new Car() { Make = "Honda", Model = "Civic", Type = "Sedan", IsAvailable = true, Price = 10.5m };
                var bmw = new Car() { Make = "BMW", Model = "3", Type = "Sedan", IsAvailable = true, Price = 20.5m };
                var mercedes = new Car() { Make = "Mercedes", Model = "X5", Type = "Jeep", IsAvailable = true, Price = 25.5m };

                context.Cities.Add(sofia);
                context.Cities.Add(burgas);
                context.Cities.Add(varna);
                context.Cities.Add(plovdiv);

                context.Offices.Add(malinov);
                context.Offices.Add(druzhba);
                context.Offices.Add(Triaditza);

                context.Cars.Add(honda);
                context.Cars.Add(bmw);
                context.Cars.Add(mercedes);

                var joro = new User() { FirstName = "Joro", FamilyName = "Petkov", PIN = "8805684234", Status = "VIP",
                    DrivingLicenseNumber = "07345223423", PhoneNumber = "0885435264" };
                context.Users.Add(joro);

                context.SaveChanges();

                var order = new Order(); //{ Car = car, User = joro };
                order.User = joro;
                order.Car = honda;
                context.Orders.Add(order);

                context.SaveChanges();
            }
            
        }
    }
}
