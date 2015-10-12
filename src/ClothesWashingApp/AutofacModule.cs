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
        private const string SqlConnectionString =
            "Data Source=.\\sqlexpress;Initial Catalog=ClothesWashing;" +
            "Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //builder.Register(c => new SqlUnitOfWorkFactory(SqlConnectionString)).As<IUnitOfWorkFactory>();
            builder.Register(c => new SqlUnitOfWork(SqlConnectionString)).As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<IUnitOfWork>().ClothesRepository).As<IClothesRepository>();
            builder.Register(c => c.Resolve<IUnitOfWork>().OutfitRepository).As<IOutfitRepository>();
            builder.Register(c => c.Resolve<IUnitOfWork>().WashSessionRepository).As<IWashSessionRepository>();

            builder.RegisterType<FindDirtyClothesService>().As<IFindDirtyClothesService>();
            builder.RegisterType<WearOutfitService>().As<IWearOutfitService>();
            builder.RegisterType<WashClothesService>().As<IWashClothesService>();
            builder.RegisterType<DefaultDateTimeProvider>().As<IDateTimeProvider>();
            builder.RegisterType<OutfitFactory>().As<IOutfitFactory>();
            builder.RegisterType<WashSessionFactory>().As<IWashSessionFactory>();
            builder.RegisterType<DefaultWearLimitPolicy>().As<IWearLimitPolicy>();

            builder.RegisterType<ImportClothesCommand>();
            builder.RegisterType<WearOutfitCommand>();
            builder.RegisterType<WashCommand>();
            builder.RegisterType<ShowDirtyClothesCommand>();
        }
    }
}
