using Client.Commands.Contracts;
using Client.Core.Contracts;
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Creating
{
    public class CreateOrderCommand : ICommand
    {
        private readonly IAutoRentContext context;
        private readonly IOrderComposer orderComposer;

        public CreateOrderCommand(IAutoRentContext context, IOrderComposer orderComposer)
        {
            this.context = context ?? throw new ArgumentNullException("context");
            this.orderComposer = orderComposer ?? throw new ArgumentNullException("orderComposer");
        }

        public string Execute(IList<string> parameters)
        {
            var car = orderComposer.SelectedCar;
            var user = orderComposer.SelectedUser;
            var departuredDate = orderComposer.DepartureDate;
            var arrivalDate = departuredDate.AddDays(orderComposer.Duration);
            car.OfficeId = orderComposer.DestinationOffice.Id;

            var order = new Order()
            {
                CarId = car.Id,
                UserId = user.Id,
                DepartureDate = departuredDate,
                ArrivalDate = arrivalDate
            };

            context.Orders.Add(order);
            context.SaveChanges();

            orderComposer.Finalize();

            return $"Order with ID {this.context.Orders.Count()} was created.";
        }
    }
}