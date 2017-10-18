using Client.Commands.Contracts;
using Data.Context;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Creating
{
    public class CreateOfficeCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public CreateOfficeCommand(IAutoRentContext context)
        {
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            var city = parameters[0];
            var address = parameters[1];
            var cars = this.context.Cars.Where(c => c.OfficeId == int.Parse(parameters[2])).ToList();

            var office = new Office()
            {
                City = city,
                Address = address,
                Cars = cars
            };

            context.Offices.Add(office);

            return $"Office with ID {this.context.Offices.Count() - 1} was created.";
        }
    }
}
