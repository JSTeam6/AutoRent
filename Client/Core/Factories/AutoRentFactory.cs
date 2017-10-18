using Client.Core.Contracts;
using Models;
using Models.Contracts;
using Models.Enum;
using System;
using System.Collections.Generic;

namespace Client.Core.Factories
{
    public class AutoRentFactory : IAutoRentFactory
    {

        public ICar CreateCar(string make, string model, string type, decimal price, bool isAvailable = true)
        {
            var car = new Car()
            {
                Make = make,
                Model = model,
                Type = type,
                Price = price,
                IsAvailable = isAvailable
            };

            return car;
        }

        public IOffice CreateOffice(string city, string address, ICollection<Car> cars = null)
        {
            var office = new Office()
            {
                City = city,
                Address = address,
                Cars = cars
            };

            return office;
        }

        public IOrder CreateOrder(Car car, User user, DateTime purchaseDate, DateTime departuredDate, DateTime arrivalDate)
        {
            var order = new Order()
            {
                Car = car,
                User = user,
                PurchaseDate = purchaseDate,
                DepartureDate = departuredDate,
                ArrivalDate = arrivalDate
            };

            return order;
        }

        public IUser CreateUser(string firstName, string familyName, string pin, string drivingLicenseNumber, string phoneNumber, UserStatus status, ICollection<Order> orders = null)
        {            
            var user = new User()
            {
                FirstName = firstName,
                FamilyName = familyName,
                PIN = pin,
                DrivingLicenseNumber = drivingLicenseNumber,
                PhoneNumber = phoneNumber,
                Status = status,
                Orders = orders
            };

            return user;
        }
    }
}
