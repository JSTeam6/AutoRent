using Client.Commands.Contracts;
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Creating
{
    public class CreateOrderCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public CreateOrderCommand(IAutoRentContext context)
        {
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            var car = context.Cars.FirstOrDefault(c => c.Make == parameters[0]);
            var user = context.Users.FirstOrDefault(u => u.FirstName + u.FamilyName == parameters[1]);
            var departuredDate = DateTime.Parse(parameters[3]);
            var arrivalDate = DateTime.Parse(parameters[4]);

            var order = new Order()
            {
                Car = car,
                User = user,
                DepartureDate = departuredDate,
                ArrivalDate = arrivalDate
            };

            context.Orders.Add(order);

            return $"Order with ID {this.context.Orders.Count() - 1} was created.";
        }
    }
}