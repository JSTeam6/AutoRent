using Client.Core.Contracts;
using System;

namespace Client.Core.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}
