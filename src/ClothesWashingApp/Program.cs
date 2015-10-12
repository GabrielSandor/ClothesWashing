using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using ClothesWashingApp.Commands;

namespace ClothesWashingApp
{
    class Program
    {
        private static IContainer _diContainer;

        static void Main(string[] args)
        {
            SetupDIContainer();

            LaunchCommand(args);

            DisposeDIContainer();

            Console.WriteLine();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        static void SetupDIContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacModule());

            _diContainer = builder.Build();
        }

        static void LaunchCommand(IReadOnlyList<string> args)
        {
            var commandTypeSwitch = args[0];

            var commandFactory = new CommandFactory(_diContainer);
            var command = commandFactory.CreateCommand(commandTypeSwitch);

            var commandArguments = args.Skip(1);
            command.Execute(commandArguments);
        }

        private static void DisposeDIContainer()
        {
            _diContainer.Dispose();
        }
    }
}
