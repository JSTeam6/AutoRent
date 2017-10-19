using Client.Commands.Contracts;
<<<<<<< HEAD
=======
using Client.Core.Contracts;
>>>>>>> z
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Creating
{
    public class CreateOrderCommand : ICommand
    {
<<<<<<< HEAD
        private readonly IAutoRentContext context;

        public CreateOrderCommand(IAutoRentContext context)
        {
=======
        private readonly IAutoRentFactory factory;
        private readonly IAutoRentContext context;

        public CreateOrderCommand(IAutoRentFactory factory, IAutoRentContext context)
        {
            this.factory = factory;
>>>>>>> z
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
<<<<<<< HEAD
            var car = context.Cars.FirstOrDefault(c => c.Make == parameters[0]);
            var user = context.Users.FirstOrDefault(u => u.FirstName + u.FamilyName == parameters[1]);
=======
            var car = context.Offices.Where(o => o.City == parameters[0]);
            var user = context.Users.Where(u => u.FirstName + u.FamilyName == parameters[1]);
>>>>>>> z
            var purchaseDate = DateTime.Parse(parameters[2]);
            var departuredDate = DateTime.Parse(parameters[3]);
            var arrivalDate = DateTime.Parse(parameters[4]);

<<<<<<< HEAD
            var order = new Order()
            {
                Car = car,
                User = user,
                PurchaseDate = purchaseDate,
                DepartureDate = departuredDate,
                ArrivalDate = arrivalDate
            };

            context.Orders.Add(order);
=======
            var office = this.factory.CreateOrder((Car)car, (User)user, purchaseDate, departuredDate, arrivalDate);
            context.Offices.Add((Office)office);
>>>>>>> z

            return $"Order with ID {this.context.Orders.Count() - 1} was created.";
        }
    }
}
