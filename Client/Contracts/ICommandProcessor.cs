using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Contracts
{
    public interface ICommandProcessor
    {
        void ProcessCommand(string commandAsString, StringBuilder builder);
    }
}
