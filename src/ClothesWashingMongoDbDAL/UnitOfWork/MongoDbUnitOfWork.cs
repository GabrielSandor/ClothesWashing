using ClothesWashing.UnitOfWork;
using ClothesWashing.Clothes;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;
using ClothesWashingMongoDbDAL.Repositories;

namespace ClothesWashingMongoDbDAL.UnitOfWork
{
    public sealed class MongoDbUnitOfWork : IUnitOfWork
    {
        public IClothesRepository ClothesRepository { get; }

        public IOutfitRepository OutfitRepository { get; }

        public IWashSessionRepository WashSessionRepository { get; }

        public MongoDbUnitOfWork(string connectionString)
        {
            var clothesDbContext = new ClothesDbContext(connectionString);

            ClothesRepository = new ClothesMongoDbRepository(clothesDbContext);
            OutfitRepository = new OutfitMongoDbRepository(clothesDbContext, ClothesRepository);
            WashSessionRepository = new WashSessionMongoDbRepository(clothesDbContext, ClothesRepository);
        }

        public void SaveChanges()
        {
        }

        public void Dispose()
        {
        }
    }
}
