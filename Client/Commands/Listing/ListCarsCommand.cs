using Client.Commands.Contracts;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Commands.Listing
{
    public class ListCarsCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public ListCarsCommand(IAutoRentContext context)
        {
            this.context = context ?? throw new ArgumentNullException("context");
        }

        public string Execute(IList<string> parameters)
        {
            if(parameters.Count < 2)
            {
                throw new ArgumentException("List cars command require 2 parameters: city and type!");
            }
            StringBuilder result = new StringBuilder();
            var city = parameters[0];
            var type = parameters[1];
            

            var listedCars = context.Cars.Where(c=>c.Office.City==city && c.Type==type).OrderBy(c=>c.Make).ThenBy(c=>c.Office.Address).ToList();
            listedCars.Select(c => result.Append($"{c.Id} .{c.Make} {c.Model} - Address: {c.Office.City}, {c.Office.Address}.\n")).ToList();

            return string.Join("  ", result);
        }
    }
}
