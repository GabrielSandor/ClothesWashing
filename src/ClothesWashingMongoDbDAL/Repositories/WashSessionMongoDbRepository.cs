using System.Collections.Generic;
using ClothesWashing.Clothes;
using ClothesWashing.Washing;
using MongoDB.Driver;

namespace ClothesWashingMongoDbDAL.Repositories
{
    sealed class WashSessionMongoDbRepository : IWashSessionRepository
    {
        private readonly IMongoCollection<WashSession> _washSessions;
        private readonly IClothesRepository _clothesRepository;

        public WashSessionMongoDbRepository(ClothesDbContext context, IClothesRepository clothesRepository)
        {
            _clothesRepository = clothesRepository;
            _washSessions = context.WashSessions;
        }

        public IEnumerable<WashSession> RetrieveAllWashSessions()
        {
            return _washSessions.AsQueryable();
        }

        public void StoreWashSession(WashSession washSession)
        {
            foreach (var clothingArticle in washSession.Clothes)
            {
                _clothesRepository.UpdateClothingArticle(clothingArticle);
            }

            _washSessions.InsertOneAsync(washSession).Wait();
        }
    }
}
