using Client.Commands.Contracts;
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Creating
{
    public class CreateOfficeCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public CreateOfficeCommand(IAutoRentContext context)
        {
            this.context = context ?? throw new ArgumentNullException("context");
        }

        public string Execute(IList<string> parameters)
        {
            var city = parameters[0];
            var address = parameters[1];
          
            var office = new Office()
            {
                City = city,
                Address = address,
            };

            context.Offices.Add(office);
            context.SaveChanges();

            return $"Office with ID {this.context.Offices.Count()} was created.";
        }
    }
}