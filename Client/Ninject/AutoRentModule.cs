using Client.Commands;
using Client.Commands.Contracts;
using Client.Commands.Creating;
using Client.Commands.Listing;
using Client.Commands.PickCar;
using Client.Commands.Update;
using Client.Core;
using Client.Core.Contracts;
using Client.Core.Factories;
using Client.Core.Providers;
using Client.Decorators;
using Data.Context;
using Ninject;
using Ninject.Modules;

namespace Client.Ninject
{
    public class AutoRentModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAutoRentContext>().To<AutoRentContext>();

            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<ICommandParser>().To<CommandParser>();
            this.Bind<ICommandProcessor>().To<CommandProcessor>();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope().Named("EngineInternal");
            this.Bind<IEngine>().To<EngineDecorator>()
                .InSingletonScope()
                .Named("Engine")
                .WithConstructorArgument(this.Kernel.Get<IEngine>("EngineInternal"));

            this.Bind<ICommand>().To<CreateCarCommand>().Named("createcar");
            this.Bind<ICommand>().To<CreateOfficeCommand>().Named("createoffice");
            this.Bind<ICommand>().To<CreateOrderCommand>().Named("createorder");
            this.Bind<ICommand>().To<CreateUserCommand>().Named("createuser");

            this.Bind<ICommand>().To<ListCarsCommand>().Named("listcars");
            this.Bind<ICommand>().To<ListCitiesCommand>().Named("listcities");
            this.Bind<ICommand>().To<ListOfficesCommand>().Named("listoffices");
            this.Bind<ICommand>().To<ListUsersCommand>().Named("listusers");

            this.Bind<ICommand>().To<AddCarToOfficeCommand>().Named("addcartooffice");

            this.Bind<ICommand>().To<ChooseCarCommand>().Named("choosecar");
            this.Bind<ICommand>().To<ChooseUserCommand>().Named("chooseuser");
            this.Bind<ICommand>().To<SetDetailsCommand>().Named("setdetails");
            this.Bind<ICommand>().To<CheckOrderCommand>().Named("checkorder");

            this.Bind<ICommand>().To<LoadCarsCommand>().Named("loadcars");
            this.Bind<ICommand>().To<LoadOfficesCommand>().Named("loadoffices");
            this.Bind<ICommand>().To<AddCarToOfficeCommand>().Named("addcartooffice");

            this.Bind<ICommand>().To<DeleteCarCommand>().Named("deletecar");

            this.Bind<IOrderComposer>().To<OrderComposer>().InSingletonScope();
        }
    }
}