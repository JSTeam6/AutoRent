using Client.Commands.Contracts;
using Data.Context;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Client.Commands.Listing
{
    public class LoadOfficesCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public LoadOfficesCommand(IAutoRentContext context)
        {
            this.context = context ?? throw new ArgumentNullException("context");
        }

        public string Execute(IList<string> parameters)
        {
            using (var contextDb = new AutoRentContext())
            {
                var json = File.ReadAllText(@"offices.json");
                var list = JsonConvert.DeserializeObject<List<Office>>(json);
                foreach (var office in list)
                {
                    contextDb.Offices.Add(office);
                }
                contextDb.SaveChanges();
            }
            
            return "Offices loaded from JSON to database!";
        }
    }
}
