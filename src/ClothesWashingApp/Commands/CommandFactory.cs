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
                case "/o": return _container.Resolve<WearOutfitCommand>();
                case "/w": return _container.Resolve<WashCommand>();
                case "/i": return _container.Resolve<ImportClothesCommand>();
                case "/d": return _container.Resolve<ShowDirtyClothesCommand>();

                default: throw new ArgumentException("Invalid command switch.", nameof(commandTypeSwitch));
            }
        }
    }
}
