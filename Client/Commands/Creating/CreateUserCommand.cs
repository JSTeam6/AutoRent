using Client.Commands.Contracts;
<<<<<<< HEAD
=======
using Client.Core.Contracts;
>>>>>>> z
using Data.Context;
using Models;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands.Creating
{
    public class CreateUserCommand : ICommand
    {
<<<<<<< HEAD
        private readonly IAutoRentContext context;

        public CreateUserCommand(IAutoRentContext context)
        {
=======
        private readonly IAutoRentFactory factory;
        private readonly IAutoRentContext context;

        public CreateUserCommand(IAutoRentFactory factory, IAutoRentContext context)
        {
            this.factory = factory;
>>>>>>> z
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            Enum.TryParse(parameters[5], out UserStatus parsedStatus);

            var firstName = parameters[0];
            var familyName = parameters[1];
            var pin = parameters[2];
            var drivingLicenseNumber = parameters[3];
            var phoneNumber = parameters[4];
            var status = parsedStatus;

<<<<<<< HEAD
            var user = new User()
            {
                FirstName = firstName,
                FamilyName = familyName,
                PIN = pin,
                DrivingLicenseNumber = drivingLicenseNumber,
                PhoneNumber = phoneNumber,
                Status = status,
            };

            context.Users.Add(user);
=======
            var user = this.factory.CreateUser(firstName, familyName, pin, drivingLicenseNumber, phoneNumber, status);
            context.Users.Add((User)user);
>>>>>>> z

            return $"Car with ID {this.context.Users.Count() - 1} was created.";
        }
    }
}
