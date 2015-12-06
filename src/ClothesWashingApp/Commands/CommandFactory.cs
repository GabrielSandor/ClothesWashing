using System;
using Autofac;

namespace ClothesWashingApp.Commands
{
    sealed class CommandFactory
    {
        private readonly IContainer _container;

        public CommandFactory(IContainer container)
        {
            _container = container;
        }

        public ICommand CreateCommand(string commandTypeSwitch)
        {
            switch (commandTypeSwitch)
            {
                case "/o":
                case "/outfit":
                    return _container.Resolve<WearOutfitCommand>();

                case "/w":
                case "/wash":
                    return _container.Resolve<WashCommand>();

                case "/i":
                case "/import":
                    return _container.Resolve<ImportClothesCommand>();

                case "/d":
                case "/showDirty":
                    return _container.Resolve<ShowDirtyClothesCommand>();

                case "/sd":
                case "/setDirty":
                    return _container.Resolve<SetDirtyClothesCommand>();

                case "/wd":
                case "/washDirty":
                    return _container.Resolve<WashDirtyClothesCommand>();

                case "/a":
                case "/showAll":
                    return _container.Resolve<ShowAllClothesCommand>();

                case "/cd":
                case "/clothesDetails":
                    return _container.Resolve<ShowClothesDetailsCommand>();

                default: throw new ArgumentException("Invalid command switch.", nameof(commandTypeSwitch));
            }
        }
    }
}
