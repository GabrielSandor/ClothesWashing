using System.Configuration;
using Autofac;
using ClothesWashing.Clothes;
using ClothesWashing.UnitOfWork;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;
using ClothesWashingEFCodeFirstDAL.UnitOfWork;
using ClothesWashingMongoDbDAL.UnitOfWork;

namespace ClothesWashingApp.RegistrationModules
{
    sealed class AutofacPersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterPersistenceLayer(builder);
        }

        private static void RegisterPersistenceLayer(ContainerBuilder builder)
        {
            var storage = ConfigurationManager.AppSettings.Get("storage");

            switch (storage)
            {
                case "sql": RegisterSqlPersistence(builder); break;
                case "nosql": RegisterNoSqlPersistence(builder); break;

                default: RegisterSqlPersistence(builder); break;
            }
        }

        private static void RegisterSqlPersistence(ContainerBuilder builder)
        {
            builder.Register(c => new SqlUnitOfWork()).As<IUnitOfWork>().InstancePerLifetimeScope();

            RegisterRepositories(builder);
        }

        private static void RegisterNoSqlPersistence(ContainerBuilder builder)
        {
            builder.Register(c => new MongoDbUnitOfWork()).As<IUnitOfWork>().InstancePerLifetimeScope();

            RegisterRepositories(builder);
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.Register(c => c.Resolve<IUnitOfWork>().ClothesRepository).As<IClothesRepository>();
            builder.Register(c => c.Resolve<IUnitOfWork>().OutfitRepository).As<IOutfitRepository>();
            builder.Register(c => c.Resolve<IUnitOfWork>().WashSessionRepository).As<IWashSessionRepository>();
        }
    }
}
