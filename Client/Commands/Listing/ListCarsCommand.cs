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
            var city = parameters[0];
            var type = parameters[1];
            var listedCars = context.Cars.Where(c=>c.Office.City==city && c.Type== type).OrderBy(c=>c.Make).ThenBy(c=>c.Office.Address).ToList();
            int counter = 0;

            listedCars.Select(c => result.Append($"{counter++, -3}. {c.Make,-12} - Address: {c.Office.City}, {c.Office.Address}.\n")).ToList();

            return string.Join("  ", result);
        }
    }
}
