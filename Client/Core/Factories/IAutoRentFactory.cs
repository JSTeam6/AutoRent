using Models;
using Models.Contracts;
using Models.Enum;
using System;
using System.Collections.Generic;

namespace Client.Core.Contracts
{
    public interface IAutoRentFactory
    {
        ICar CreateCar(string make, string model, string type, decimal price, bool isAvailable = true);

        IOffice CreateOffice(string city, string address, ICollection<Car> cars = null);

        IOrder CreateOrder(Car car, User user, DateTime purchaseDate, DateTime departuredDate, DateTime arrivalDate);

        IUser CreateUser(string firstName, string familyName, string pin, string drivingLicenseNumber, string phoneNumber, UserStatus status, ICollection<Order> orders = null);
    }
}
