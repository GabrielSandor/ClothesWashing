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

        public MongoDbUnitOfWork()
        {
            var clothesDbContext = new ClothesDbContext();

            ClothesRepository = new ClothesMongoDbRepository(clothesDbContext);
        }

        public void SaveChanges()
        {
        }

        public void Dispose()
        {
        }
    }
}
