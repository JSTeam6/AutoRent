using Client.Commands.Contracts;
using Client.Core.Contracts;
using Data.Context;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Creating
{
    public class CreateCarCommand : ICommand
    {
        private readonly IAutoRentFactory factory;
        private readonly IAutoRentContext context;

        public CreateCarCommand(IAutoRentFactory factory, IAutoRentContext context)
        {
            this.factory = factory;
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            var make = parameters[0];
            var model = parameters[1];
            var type = parameters[2];
            var price = decimal.Parse(parameters[3]);
            var isAvailable = bool.Parse(parameters[4]);

            var car = this.factory.CreateCar(make, model, type, price, isAvailable);
            context.Cars.Add((Car)car);

            return $"Car with ID {this.context.Cars.Count() - 1} was created.";
        }
    }
}
