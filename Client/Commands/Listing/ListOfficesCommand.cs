﻿using Client.Commands.Contracts;
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
            this.context = context ?? throw new ArgumentNullException("context");
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder result = new StringBuilder();
            var city = parameters[0];
            var listedOffices = context.Offices.Where(c => c.City == city).ToList();
            listedOffices.Select(o => result.Append($"*- {o.City}, Address: {o.Address}.\n")).ToList();

            StartUp.PDFsb.Append($"listoffices {city} \n" + result + "\n");

            return string.Join("  ", result);
        }
    }
}
