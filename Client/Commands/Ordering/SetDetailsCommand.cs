using Client.Commands.Contracts;
using Client.Core.Contracts;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands
{
    public class SetDetailsCommand : ICommand
    {
        private readonly IAutoRentContext context;
        private readonly IOrderComposer orderComposer;

        public SetDetailsCommand(IAutoRentContext context, IOrderComposer orderComposer)
        {
            this.context = context ?? throw new ArgumentNullException("context");
            this.orderComposer = orderComposer ?? throw new ArgumentNullException("orderComposer");
        }

        public string Execute(IList<string> parameters)
        {
            var destinationOfficeId = int.Parse(parameters[0]);
            var departureDate = DateTime.Parse(parameters[1]);
            var duration = int.Parse(parameters[2]);

            var destinationOffice = context.Offices.FirstOrDefault(o => o.Id == destinationOfficeId);

            orderComposer.DestinationOffice = destinationOffice;
            orderComposer.DepartureDate = departureDate;
            orderComposer.Duration = duration;

            string result = $"You have set:\nDepartureDate {orderComposer.DepartureDate.ToShortDateString()}, Duration: {orderComposer.Duration}\nDestination: {orderComposer.DestinationOffice.City}, {orderComposer.DestinationOffice.Address}.";

            return result;
        }
    }
}
