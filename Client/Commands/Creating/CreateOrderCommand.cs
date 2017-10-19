using Client.Commands.Contracts;
using Client.Core.Contracts;
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Creating
{
    public class CreateOrderCommand : ICommand
    {
        private readonly IAutoRentFactory factory;
        private readonly IAutoRentContext context;

        public CreateOrderCommand(IAutoRentFactory factory, IAutoRentContext context)
        {
            this.factory = factory;
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            var car = context.Offices.Where(o => o.City == parameters[0]);
            var user = context.Users.Where(u => u.FirstName + u.FamilyName == parameters[1]);
            var purchaseDate = DateTime.Parse(parameters[2]);
            var departuredDate = DateTime.Parse(parameters[3]);
            var arrivalDate = DateTime.Parse(parameters[4]);

            var office = this.factory.CreateOrder((Car)car, (User)user, purchaseDate, departuredDate, arrivalDate);
            context.Offices.Add((Office)office);

            return $"Order with ID {this.context.Orders.Count() - 1} was created.";
        }
    }
}
