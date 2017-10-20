using Client.Commands.Contracts;
using Client.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Client.Commands
{
    public class CheckOrderCommand : ICommand
    {
        private readonly IOrderComposer orderComposer;

        public CheckOrderCommand(IOrderComposer orderComposer)
        {
            this.orderComposer = orderComposer ?? throw new ArgumentNullException("orderComposer");
        }

        public string Execute(IList<string> parameters)
        {
            var car = orderComposer.SelectedCar;
            var user = orderComposer.SelectedUser;
            var office = orderComposer.DestinationOffice;

            var firstName = user != null ? user.FirstName : "[not set]";
            var familyName = user != null ? user.FamilyName : "[not set]";
            var make = car != null ? car.Make : "[not set]";
            var model = car != null ? car.Model : "[not set]";
            var city = office != null ? office.City : "[not set]";
            var address = office != null ? office.Address : "[not set]";
            var departureDate = orderComposer.DepartureDate.Year != 0001 ? orderComposer.DepartureDate.ToShortDateString() : "[not set]";
            var duration = orderComposer.Duration != 0 ? orderComposer.Duration.ToString() : "[not set]";
            var cost = car != null && orderComposer.Duration != 0 ? (car.Price * orderComposer.Duration).ToString() : "[not set]";

            string result = $"Order Details:\nUser: {firstName} {familyName}\nCar: {make} {model}\nDestination: {city}, {address}\nDeparture Date: {departureDate}, Duration: {duration}\nOrder cost: $ {cost}.";

            return result;
        }
    }
}
