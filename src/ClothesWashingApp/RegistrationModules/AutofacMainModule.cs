using Autofac;
using ClothesWashing.Services;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;
using ClothesWashing.Wearing.WearLimits;
using ClothesWashingApp.Commands;

namespace ClothesWashingApp.RegistrationModules
{
    sealed class AutofacMainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c => builder).AsSelf();

            builder.RegisterType<FindDirtyClothesService>().As<IFindDirtyClothesService>();
            builder.RegisterType<WearOutfitService>().As<IWearOutfitService>();
            builder.RegisterType<WashClothesService>().As<IWashClothesService>();
            builder.RegisterType<DefaultDateTimeProvider>().As<IDateTimeProvider>();
            builder.RegisterType<OutfitFactory>().As<IOutfitFactory>();
            builder.RegisterType<WashSessionFactory>().As<IWashSessionFactory>();

            builder.RegisterType<JsonWearLimitPolicy>()
                   .As<IWearLimitPolicy>()
                   .WithParameter("jsonFilePath", "SetupData\\WearLimits.json");

            RegisterCommands(builder);
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder.RegisterType<CommandFactory>().As<ICommandFactory>();

            builder.RegisterType<ImportClothesCommand>();
            builder.RegisterType<WearOutfitCommand>();
            builder.RegisterType<WashCommand>();
            builder.RegisterType<ShowDirtyClothesCommand>();
            builder.RegisterType<ShowAllClothesCommand>();
            builder.RegisterType<ShowClothesDetailsCommand>();
            builder.RegisterType<WashDirtyClothesCommand>();
            builder.RegisterType<SetDirtyClothesCommand>();
            builder.RegisterType<NullCommand>();
        }
    }
}
