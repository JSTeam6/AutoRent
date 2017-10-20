using Client.Commands.Contracts;
using Data.Context;
using MoreLinq;
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
            StringBuilder result = new StringBuilder();
            var city = parameters[0];
            var type = parameters[1];

            var listedCars = context.Cars
                .Where(c => c.Office.City == city && c.Type == type)
                .DistinctBy(c => c.Model)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Office.Address)
                .ToList();
            listedCars.Select(c => result.Append($"{c.Id,3} {c.Make,-10} {c.Model,-10} {c.Office.City}, {c.Office.Address}.\n")).ToList();

            StartUp.PDFsb.Append($"listcars {city} {type} \n" + result + "\n");

            return result.ToString();
        }
    }
}
