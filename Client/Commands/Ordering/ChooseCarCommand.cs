using Client.Commands.Contracts;
using Client.Core.Contracts;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.PickCar
{
    public class ChooseCarCommand : ICommand
    {
        private readonly IAutoRentContext context;
        private readonly IOrderComposer orderComposer;

        public ChooseCarCommand(IAutoRentContext context, IOrderComposer orderComposer)
        {
            this.context = context ?? throw new ArgumentNullException("context");
            this.orderComposer = orderComposer ?? throw new ArgumentNullException("orderComposer");
        }

        public string Execute(IList<string> parameters)
        {
            var carId = int.Parse(parameters[0]);
            var selectedCar = context.Cars.FirstOrDefault(c => c.Id == carId);
            this.orderComposer.SelectedCar = selectedCar;

            string result = $"You have chosen {selectedCar.Make} {selectedCar.Model}!";

            return result;
        }
    }
}
