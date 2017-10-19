using Data.Context;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Xml;

namespace Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AutoRentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AutoRentContext context)
        {
            using (var contextDb = new AutoRentContext())
            {

                //Offices
                var json = File.ReadAllText(@"offices.json");
                var list = JsonConvert.DeserializeObject<List<Office>>(json);
                foreach (var office in list)
                {
                    contextDb.Offices.Add(office);
                }
                contextDb.SaveChanges();

                //Cars
                XmlDocument xmldoc = new XmlDocument();
                XmlNodeList xmlnode;
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
        }
    }
}
