using Client.Commands.Contracts;
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Client.Commands.Listing
{
    public class LoadCarsCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public LoadCarsCommand(IAutoRentContext context)
        {
            this.context = context ?? throw new ArgumentNullException("context");
        }

        public string Execute(IList<string> parameters)
        {
            using (var contextDb = new AutoRentContext())
            {
                XmlDocument xmldoc = new XmlDocument();
                var xmlfile = File.ReadAllText(@"cars.xml");
                xmldoc.LoadXml(xmlfile);

                XmlElement root = xmldoc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("row");
                foreach (XmlNode node in nodes)
                {
                    var car = new Car()
                    {
                        Type = node.ChildNodes.Item(0).FirstChild.InnerText,
                        Model = node.ChildNodes.Item(1).FirstChild.InnerText,
                        Make = node.ChildNodes.Item(2).FirstChild.InnerText,
                        Price = decimal.Parse(node.ChildNodes.Item(3).FirstChild.InnerText),
                        OfficeId = int.Parse(node.ChildNodes.Item(4).FirstChild.InnerText),
                    };

                    contextDb.Cars.Add(car);
                }
                contextDb.SaveChanges();
            }

            return "Cars loaded from XML to database!";
        }
    }
}
