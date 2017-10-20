using Client.Commands.Contracts;
using Client.Core.Contracts;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Commands
{
    public class ChooseUserCommand : ICommand
    {
        private readonly IAutoRentContext context;
        private readonly IOrderComposer orderComposer;

        public ChooseUserCommand(IAutoRentContext context, IOrderComposer orderComposer)
        {
            this.context = context ?? throw new ArgumentNullException("context");
            this.orderComposer = orderComposer ?? throw new ArgumentNullException("orderComposer");
        }

        public string Execute(IList<string> parameters)
        {
            var pin = parameters[0];
            var selectedUser = context.Users.FirstOrDefault(c => c.PIN == pin);

            orderComposer.SelectedUser = selectedUser;

            string result = $"User {selectedUser.FirstName} {selectedUser.FamilyName} was selected.";

            return result;
        }
    }
}
