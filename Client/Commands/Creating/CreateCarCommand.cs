using Client.Commands.Contracts;
<<<<<<< HEAD
=======
using Client.Core.Contracts;
>>>>>>> z
using Data.Context;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Creating
{
    public class CreateCarCommand : ICommand
    {
<<<<<<< HEAD
        private readonly IAutoRentContext context;

        public CreateCarCommand(IAutoRentContext context)
        {
=======
        private readonly IAutoRentFactory factory;
        private readonly IAutoRentContext context;

        public CreateCarCommand(IAutoRentFactory factory, IAutoRentContext context)
        {
            this.factory = factory;
>>>>>>> z
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            var make = parameters[0];
            var model = parameters[1];
            var type = parameters[2];
            var price = decimal.Parse(parameters[3]);
            var isAvailable = bool.Parse(parameters[4]);

<<<<<<< HEAD
            var car = new Car()
            {
                Make = make,
                Model = model,
                Type = type,
                Price = price,
                IsAvailable = isAvailable
            };

            context.Cars.Add(car);
=======
            var car = this.factory.CreateCar(make, model, type, price, isAvailable);
            context.Cars.Add((Car)car);
>>>>>>> z

            return $"Car with ID {this.context.Cars.Count() - 1} was created.";
        }
    }
}
