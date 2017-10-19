using Client.Commands.Contracts;
using Data.Context;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            this.context = context ?? throw new ArgumentNullException("context");
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder result = new StringBuilder();
            var listedCities = context.Offices.Select(c => c.City).ToList();
            listedCities.Select(c => result.Append($"*- {c} \n")).ToList();

            StartUp.PDFsb.Append("listcities \n" + result + "\n");

            return string.Join("  ", result);
        }
    }
}
