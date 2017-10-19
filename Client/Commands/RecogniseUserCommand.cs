using Client.Commands.Contracts;
using Client.Core.Contracts;
using Client.Core.Factories;
using Data.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands
{
    public class RecogniseUserCommand : ICommand
    {
        private readonly IAutoRentContext context;

        private readonly IOrderComposer database;

        public RecogniseUserCommand(IAutoRentContext context, IOrderComposer database)
        {
            this.context = context;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var pin = parameters[2];
            var drivingLicense = parameters[3];
            var phoneNumber = parameters[4];
            var user = context.Users.FirstOrDefault(c => c.PIN == pin);

            string result;
            if (user == null)
            {
                user = new User()
                {
                    FirstName = firstName,
                    FamilyName = lastName,
                    PIN = pin,
                    DrivingLicenseNumber = drivingLicense,
                    PhoneNumber = phoneNumber
                };

                context.Users.Add(user);
                context.SaveChanges();

                database.User = user;

                result = "Welcome! You are on the way to complete your first order. Please specify your destination and" +
                    "the period you would use the car for: order [destination] [duration]";
            }
            else
            {
                database.User = user;
                result = "To confirm your order, please specify your departure date, destination," +
                    "the period you would use the car for: order [dd/mm/yyyy] [destination] [duration] ";
            }

            return result;
        }
    }
}
