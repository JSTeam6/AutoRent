using Client.Commands.Contracts;
using System.Collections.Generic;

namespace Client.Core.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
