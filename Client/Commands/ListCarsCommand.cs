using Client.Commands.Contracts;
using Client.Core.Contracts;
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
            var listedCars = context.Cars.Where(c=>c.Office.City==city).OrderBy(c=>c.Make).ThenBy(c=>c.Office.Address).ToList();
            listedCars.Select(c => result.Append($"{c.Id}. {c.Make,-12} {c.Model,-5} - Address: {c.Office.City}, {c.Office.Address}. Office name ${c.Office.OfficeName}\n")).ToList();
            result.AppendLine("To pick a car, specify its row number: choose [id]");

            return string.Join("  ", result);
        }
    }
}
