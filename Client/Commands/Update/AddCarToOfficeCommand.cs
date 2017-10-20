using Client.Commands.Contracts;
using Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Update
{
    public class AddCarToOfficeCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public AddCarToOfficeCommand(IAutoRentContext context)
        {
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            var carId = int.Parse(parameters[0]);
            var officeId = int.Parse(parameters[1]);

            this.context.Cars.Single(c => c.Id == carId).OfficeId = officeId;

            return $"Car with ID {carId} was added to Office with ID {officeId}";
        }
    }
}
