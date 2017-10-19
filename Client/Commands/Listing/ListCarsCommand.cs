using Client.Commands.Contracts;
using Data.Context;
<<<<<<< HEAD
using System;
=======
>>>>>>> z
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
<<<<<<< HEAD
            this.context = context ?? throw new ArgumentNullException("context");
=======
            this.context = context;
>>>>>>> z
        }

        public string Execute(IList<string> parameters)
        {
<<<<<<< HEAD
            if(parameters.Count < 2)
            {
                throw new ArgumentException("List cars command require 2 parameters: city and type!");
            }
            StringBuilder result = new StringBuilder();
            int counter = 1;
            var city = parameters[0];
            var type = parameters[1];
            

            var listedCars = context.Cars.Where(c=>c.Office.City==city).Where(c=>c.Type==type).OrderBy(c=>c.Make).ThenBy(c=>c.Office.Address).ToList();
            listedCars.Select(c => result.Append($"{counter++}.{c.Make} {c.Model} - Address: {c.Office.City}, {c.Office.Address}.\n")).ToList();
=======
            StringBuilder result = new StringBuilder();
            var city = parameters[0];
            var type = parameters[1];
            var listedCars = context.Cars.Where(c=>c.Office.City==city && c.Type== type).OrderBy(c=>c.Make).ThenBy(c=>c.Office.Address).ToList();
            int counter = 0;

            listedCars.Select(c => result.Append($"{counter++, -3}. {c.Make,-12} - Address: {c.Office.City}, {c.Office.Address}.\n")).ToList();
>>>>>>> z

            return string.Join("  ", result);
        }
    }
}
