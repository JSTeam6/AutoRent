using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Core.Providers
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
