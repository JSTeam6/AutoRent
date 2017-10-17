using Academy.Core.Contracts;
using System;
using System.Text;

namespace Academy.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private ICommandParser commandParser;

        public CommandProcessor(ICommandParser commandParser)
        {
            this.commandParser = commandParser;
        }

        public void ProcessCommand(string commandAsString, StringBuilder builder)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.commandParser.ParseCommand(commandAsString);
            var parameters = this.commandParser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            builder.AppendLine(executionResult);
        }
    }
}
