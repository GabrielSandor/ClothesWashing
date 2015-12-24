using System.Collections.Generic;
using System.Linq;
using ClothesWashing.Clothes;
using ClothesWashing.Washing;
using ClothesWashingMongoDbDAL.States;
using MongoDB.Driver;

namespace ClothesWashingMongoDbDAL.Repositories
{
    sealed class WashSessionMongoDbRepository : IWashSessionRepository
    {
        private readonly IMongoCollection<WashSessionState> _washSessions;
        private readonly IClothesRepository _clothesRepository;

        public WashSessionMongoDbRepository(ClothesDbContext context, IClothesRepository clothesRepository)
        {
            _clothesRepository = clothesRepository;
            _washSessions = context.WashSessions;
        }

        public IEnumerable<WashSession> RetrieveAllWashSessions()
        {
            var states = _washSessions.AsQueryable().ToList();
            return states.Select(ws => new WashSession(ws));
        }

        public void StoreWashSession(WashSession washSession)
        {
            foreach (var clothingArticle in washSession.Clothes)
            {
                _clothesRepository.UpdateClothingArticle(clothingArticle);
            }

            var state = (WashSessionState)washSession.StorageState;
            _washSessions.InsertOneAsync(state).Wait();
        }
    }
}
