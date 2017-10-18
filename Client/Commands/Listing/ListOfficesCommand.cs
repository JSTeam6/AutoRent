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
    public class ListOfficesCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public ListOfficesCommand(IAutoRentContext context)
        {
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder result = new StringBuilder();
            int counter = 1;
            var city = parameters[0];
            var listedOffices = context.Offices.Where(c => c.City == city).ToList();
            listedOffices.Select(c => result.Append($"{counter++}. Address: {c.Address}.\n")).ToList();

            return string.Join("  ", result);
        }
    }
}
