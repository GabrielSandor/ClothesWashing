using Autofac;
using ClothesWashing.Clothes;
using ClothesWashing.Services;
using ClothesWashing.UnitOfWork;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;
using ClothesWashing.Wearing.WearLimits;
using ClothesWashingApp.Commands;
using ClothesWashingEFCodeFirstDAL.UnitOfWork;

namespace ClothesWashingApp
{
    sealed class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterUnitOfWorkWithRepositories(builder);

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
            builder.RegisterType<ImportClothesCommand>();
            builder.RegisterType<WearOutfitCommand>();
            builder.RegisterType<WashCommand>();
            builder.RegisterType<ShowDirtyClothesCommand>();
            builder.RegisterType<ShowAllClothesCommand>();
            builder.RegisterType<ShowClothesDetailsCommand>();
            builder.RegisterType<WashDirtyClothesCommand>();
        }

        private static void RegisterUnitOfWorkWithRepositories(ContainerBuilder builder)
        {
            builder.Register(c => new SqlUnitOfWork()).As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<IUnitOfWork>().ClothesRepository).As<IClothesRepository>();
            builder.Register(c => c.Resolve<IUnitOfWork>().OutfitRepository).As<IOutfitRepository>();
            builder.Register(c => c.Resolve<IUnitOfWork>().WashSessionRepository).As<IWashSessionRepository>();
        }
    }
}
