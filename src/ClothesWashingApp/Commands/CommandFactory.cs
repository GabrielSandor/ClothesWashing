using System;
using Autofac;

namespace ClothesWashingApp.Commands
{
    sealed class CommandFactory : ICommandFactory
    {
        private readonly ILifetimeScope _container;

        public CommandFactory(ILifetimeScope container)
        {
            _container = container;
        }

        public ICommand CreateCommand(string commandTypeSwitch)
        {
            switch (commandTypeSwitch)
            {
                case "/o":
                case "o":
                case "/outfit":
                case "outfit":
                    return _container.Resolve<WearOutfitCommand>();

                case "/w":
                case "w":
                case "/wash":
                case "wash":
                    return _container.Resolve<WashCommand>();

                case "/i":
                case "i":
                case "/import":
                case "import":
                    return _container.Resolve<ImportClothesCommand>();

                case "/d":
                case "d":
                case "/showDirty":
                case "showDirty":
                    return _container.Resolve<ShowDirtyClothesCommand>();

                case "/sd":
                case "sd":
                case "/setDirty":
                case "setDirty":
                    return _container.Resolve<SetDirtyClothesCommand>();

                case "/wd":
                case "wd":
                case "/washDirty":
                case "washDirty":
                    return _container.Resolve<WashDirtyClothesCommand>();

                case "/a":
                case "a":
                case "/showAll":
                case "showAll":
                    return _container.Resolve<ShowAllClothesCommand>();

                case "/cd":
                case "cd":
                case "/clothesDetails":
                case "clothesDetails":
                    return _container.Resolve<ShowClothesDetailsCommand>();

                case "":
                case null:
                    return _container.Resolve<NullCommand>();

                default: throw new ArgumentException("Invalid command switch.", nameof(commandTypeSwitch));
            }
        }
    }
}
