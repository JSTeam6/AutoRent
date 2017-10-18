using System.Collections.Generic;

namespace Client.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
