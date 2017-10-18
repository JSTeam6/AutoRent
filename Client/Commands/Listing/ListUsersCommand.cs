﻿using Client.Commands.Contracts;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IAutoRentContext context;

        public ListUsersCommand(IAutoRentContext context)
        {
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder result = new StringBuilder();
            int counter = 1;
            var listedUsers = context.Users.Select(u => result.Append($"{counter}.{u.FirstName} {u.FamilyName} {u.PhoneNumber}.\n")).ToList();

            return string.Join("  ", result);
        }
    }
}