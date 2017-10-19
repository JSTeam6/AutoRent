using Client.Commands.Contracts;
using Client.Core.Contracts;
using Client.Core.Factories;
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Commands
{
    public class ConfirmOrderCommand : ICommand
    {
        private readonly IAutoRentContext context;

        private readonly IOrderComposer database;

        //private readonly ICommandFactory factory;

        public ConfirmOrderCommand(IAutoRentContext context, IOrderComposer database) //ICommandFactory factory
        {
            this.context = context;
            this.database = database;
            //this.factory = factory;
        }

        public string Execute(IList<string> parameters)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            var departureDate = DateTime.Parse(parameters[0]);
            var destination = parameters[1];
            var duration = int.Parse(parameters[2]);
            var carAvailableAgainAfter = departureDate.AddDays(duration + 1);

            var carId = database.CarId;
            var user = database.User;
            //var order = factory.GetCommand("createorder");

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

            //context.Offices.Where(o => o.City == destination).

            return result;
        }
    }
}
