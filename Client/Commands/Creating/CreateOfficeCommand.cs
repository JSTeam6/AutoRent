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
    public class CreateOfficeCommand : ICommand
    {
<<<<<<< HEAD
        private readonly IAutoRentContext context;

        public CreateOfficeCommand(IAutoRentContext context)
        {
=======
        private readonly IAutoRentFactory factory;
        private readonly IAutoRentContext context;

        public CreateOfficeCommand(IAutoRentFactory factory, IAutoRentContext context)
        {
            this.factory = factory;
>>>>>>> z
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            var city = parameters[0];
            var address = parameters[1];
<<<<<<< HEAD
            var cars = this.context.Cars.Where(c => c.OfficeId == int.Parse(parameters[2])).ToList();

            var office = new Office()
            {
                City = city,
                Address = address,
                Cars = cars
            };

            context.Offices.Add(office);
=======
            var cars = this.context.Cars.Where(c => c.OfficeId == int.Parse(parameters[2])); //?????????????????????????????????????????????????????????????????????????????????????????????????????????????????????

            var office = this.factory.CreateOffice(city, address);
            context.Offices.Add((Office)office);
>>>>>>> z

            return $"Office with ID {this.context.Offices.Count() - 1} was created.";
        }
    }
}
