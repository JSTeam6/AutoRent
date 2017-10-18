﻿using Client.Core.Contracts;
using System;

namespace Client.Decorators
{
    public class EngineDecorator : IEngine
    {
        private readonly IEngine engine;
        private readonly IWriter writer;

        public EngineDecorator(IEngine engine, IWriter writer)
        {
            this.engine = engine ?? throw new ArgumentNullException("Engine can't be null!");
            this.writer = writer ?? throw new ArgumentNullException("Writer can't be null!");
        }

        public void Start()
        {
            string entryMenu = $@"                                            
 █████╗ ██╗   ██╗████████╗ ██████╗ ██████╗ ███████╗███╗   ██╗████████╗
██╔══██╗██║   ██║╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝████╗  ██║╚══██╔══╝
███████║██║   ██║   ██║   ██║   ██║██████╔╝█████╗  ██╔██╗ ██║   ██║   
██╔══██║██║   ██║   ██║   ██║   ██║██╔══██╗██╔══╝  ██║╚██╗██║   ██║   
██║  ██║╚██████╔╝   ██║   ╚██████╔╝██║  ██║███████╗██║ ╚████║   ██║   
╚═╝  ╚═╝ ╚═════╝    ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝   ╚═╝                      
Rent-a-Car management service

Commands Menu:
listcars [city] [car type] - lists available cars of selected type
...
exit - terminates the system
Enter command: ";
            this.writer.Write(entryMenu);
            this.engine.Start();
            this.writer.Write($"Exiting service" + Environment.NewLine);
        }
    }
}