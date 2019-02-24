using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using ClothesWashingApp.Commands;
using ClothesWashingApp.RegistrationModules;

namespace ClothesWashingApp
{
    sealed class Program
    {
        private static IContainer _diContainer;

        static void Main(string[] args)
        {
            SetupDIContainer();

            LaunchCommand(args);

            string input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                var inputTokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                LaunchCommand(inputTokens);
                Console.WriteLine();
            }

            DisposeDIContainer();

            Console.WriteLine();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        static void SetupDIContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacMainModule());
            builder.RegisterModule(new AutofacPersistenceModule());

            _diContainer = builder.Build();
        }

        static void LaunchCommand(IReadOnlyList<string> args)
        {
            var commandTypeSwitch = args.Any() ? args[0] : null;

            var commandFactory = _diContainer.Resolve<ICommandFactory>();
            ICommand command;

            try
            {
                command = commandFactory.CreateCommand(commandTypeSwitch);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            var commandArguments = args.Skip(1);
            command.Execute(commandArguments);
        }

        private static void DisposeDIContainer()
        {
            _diContainer.Dispose();
        }
    }
}
