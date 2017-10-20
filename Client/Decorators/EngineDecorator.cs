using Client.Core.Contracts;
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
CREATING
createcar [make] [model] [type] [price] [available] [officeId] - creates new car
createoffice [city] [address] - creates new office
createuser [firstName] [familyName] [pin] [drivingLicenseNumber] [phoneNumber] [status] - creates new user

LISTING
listcars [city] [car type] - returns available cars of selected type
listcities - returns cities where offices are located
listoffices [city] - returns offices in a sellected city
listusers - returns all users

ORDERING
choosecar [carId] - adds the selected car to the order
chooseuser [pin] - adds the selected user to the order
setdetails [destinationOffice] [departureDate (dd/mm/yyyy)] [duration] - sets order details


OTHER
exit - terminates the system

Enter command: ";
            this.writer.Write(entryMenu);
            this.engine.Start();
            this.writer.Write($"Exiting service" + Environment.NewLine);
        }
    }
}
