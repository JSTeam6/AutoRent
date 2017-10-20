using Client.Commands.Contracts;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public ListUsersCommand(IAutoRentContext context)
        {
            this.context = context ?? throw new ArgumentNullException("context");
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder result = new StringBuilder();
            var listedUsers = context.Users.ToList();
            listedUsers.Select(u => result.Append($"{u.Id,3}. {u.FirstName,-10}{u.FamilyName,-10}{u.PhoneNumber,-10}.\n")).ToList();

            StartUp.PDFsb.Append("listusers \n" + result + "\n");
            
            return result.ToString();
        }
    }
}
