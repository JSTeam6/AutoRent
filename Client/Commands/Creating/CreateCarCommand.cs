using Client.Commands.Contracts;
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Creating
{
    public class CreateCarCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public CreateCarCommand(IAutoRentContext context)
        {
            this.context = context ?? throw new ArgumentNullException("context");
        }

        public string Execute(IList<string> parameters)
        {
            var make = parameters[0];
            var model = parameters[1];
            var type = parameters[2];
            var price = decimal.Parse(parameters[3]);
            var isAvailable = bool.Parse(parameters[4]);
            var officeId = int.Parse(parameters[5]);

            var car = new Car()
            {
                Make = make,
                Model = model,
                Type = type,
                Price = price,
                OfficeId = officeId
            };

            context.Cars.Add(car);
            context.SaveChanges();

            return $"Car with ID {this.context.Cars.Count()} was created.";
        }
    }
}
