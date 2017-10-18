using Client.Commands.Contracts;
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands.Listing
{
    public class ListCitiesCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public ListCitiesCommand(IAutoRentContext context)
        {
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder result = new StringBuilder();
            int counter = 1;
            var listedCities = context.Offices.Select(c => c.City).ToList();
            listedCities.Select(c => result.Append($"{counter++}. {c} \n")).ToList();

            return string.Join("  ", result);
        }
    }
}
