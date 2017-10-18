using Client.Commands.Contracts;

namespace Client.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string commandName);
    }
}
