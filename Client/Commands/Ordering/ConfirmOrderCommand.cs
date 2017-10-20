using Client.Commands.Contracts;
using Client.Core.Contracts;
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Client.Commands
{
    public class ConfirmOrderCommand : ICommand
    {
        private readonly IAutoRentContext context;
        private readonly IOrderComposer orderComposer;
        
        public ConfirmOrderCommand(IAutoRentContext context, IOrderComposer orderComposer)
        {
            this.context = context ?? throw new ArgumentNullException("context");
            this.orderComposer = orderComposer ?? throw new ArgumentNullException("orderComposer");
        }

        public string Execute(IList<string> parameters)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            var departureDate = DateTime.Parse(parameters[0]);
            var destination = parameters[1];
            var duration = int.Parse(parameters[2]);
            var carAvailableAgainAfter = departureDate.AddDays(duration + 1);

            var carId = orderComposer.SelectedCar.Id;
            var user = orderComposer.SelectedUser;

            var order = new Order()
            {
                CarId = carId,
                User = (User)user,
                DepartureDate = departureDate,
                ArrivalDate = departureDate.AddDays(duration)
            };

            context.Orders.Add(order);
            context.SaveChanges();

            string result = string.Format("You have succesfully booked your AutoRent car! It would be waiting for you on" + $"{order.DepartureDate.ToString()}" +
                $"{order.Car.Office.Address.ToString()}, {order.Car.Office.City.ToString()}.");

            return result;
        }
    }
}
