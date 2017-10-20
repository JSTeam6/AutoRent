using Client.Commands.Contracts;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Creating
{
    public class DeleteCarCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public DeleteCarCommand(IAutoRentContext context)
        {
            this.context = context ?? throw new ArgumentNullException("context");
        }

        public string Execute(IList<string> parameters)
        {
            var carId = int.Parse(parameters[0]);
            var selectedCar = context.Cars.FirstOrDefault(c => c.Id == carId);
            
            context.Cars.Remove(selectedCar);
            context.SaveChanges();

            return $"Car with ID {carId} was deleted.";
        }
    }
}
