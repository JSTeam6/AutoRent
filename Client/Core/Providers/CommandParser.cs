using Client.Commands.Contracts;
using Client.Core.Contracts;
using Client.Core.Factories;
using System.Collections.Generic;
using System.Linq;

namespace Client.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            string commandName = fullCommand.Split(' ')[0];

            ICommand command = this.commandFactory.GetCommand(commandName);

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
