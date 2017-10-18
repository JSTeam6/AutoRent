using Client.Commands.Contracts;
using Data.Context;
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
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder result = new StringBuilder();
            int counter = 1;
            var city = parameters[0];
            var listedCars = context.Cars.Where(c=>c.Office.City==city).OrderBy(c=>c.Make).ThenBy(c=>c.Office.Address).ToList();
            listedCars.Select(c => result.Append($"{counter++}.{c.Make,-12} - Address: {c.Office.City}, {c.Office.Address}.\n")).ToList();

            return string.Join("  ", result);
        }
    }
}
