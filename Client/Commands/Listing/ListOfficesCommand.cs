using Client.Commands.Contracts;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Commands.Listing
{
    public class ListOfficesCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public ListOfficesCommand(IAutoRentContext context)
        {
            this.context = context ?? throw new ArgumentNullException("context");
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder result = new StringBuilder();
            var city = parameters[0];
            var listedOffices = context.Offices.Where(o => o.City == city).OrderBy(o => o.City).ToList();
            listedOffices.Select(o => result.Append($"Id: {o.Id,3}. Address: {o.City}, {o.Address}.\n")).ToList();

            StartUp.PDFsb.Append($"listoffices {city} \n" + result + "\n");

            return result.ToString();
        }
    }
}
