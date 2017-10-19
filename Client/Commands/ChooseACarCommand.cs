using Client.Commands.Contracts;
using Client.Core.Contracts;
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands.PickCar
{
    public class ChooseACarCommand : ICommand
    {
        private readonly IAutoRentContext context;

        private readonly IOrderComposer database;

        public ChooseACarCommand(IAutoRentContext context, IOrderComposer database)
        {
            this.context = context;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var carId = int.Parse(parameters[0]);
            //var make = parameters[1];
            //var model = parameters[2];
            var car = context.Cars.SingleOrDefault(c => c.Id == carId);

            Car carReady = new Car()
            {
                Type = car.Type,
                Make = car.Make,
                Model = car.Model,
                Price = car.Price,
                OfficeId = car.OfficeId
            };

            this.database.CarId = carId;

            string result = $"You have chosen a great {carReady.Make} {carReady.Model}!" + " " +
                "Please enter your personal details: user [FirstName][FamilyName][PIN][DrivingLicense][phoneNumber]";

            return result;
        }
    }
}
