using Client.Core.Contracts;
using System;
using System.Text;

namespace Client.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandParser commandParser;
        private readonly ICommandProcessor commandProcessor;

        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        private readonly StringBuilder builder = new StringBuilder();

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser, ICommandProcessor commandProcessor)
        {
            this.reader = reader ?? throw new ArgumentNullException("Reader can't be null!");
            this.writer = writer ?? throw new ArgumentNullException("Writer can't be null!");
            this.commandParser = commandParser ?? throw new ArgumentNullException("Command Parser can't be null!");
            this.commandProcessor = commandProcessor ?? throw new ArgumentNullException("Command Processor can't be null!");
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();
                    if (commandAsString == TerminationCommand)
                    {
                        this.writer.Write(this.builder.ToString());
                        break;
                    }

                    this.commandProcessor.ProcessCommand(commandAsString, builder);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");
                }
                catch (Exception ex)
                {
                    this.builder.AppendLine(ex.Message);
                }
            }
        }
    }
}
