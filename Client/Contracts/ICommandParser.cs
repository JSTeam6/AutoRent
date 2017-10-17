using Academy.Commands.Contracts;
using System.Collections.Generic;

namespace Academy.Core.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
