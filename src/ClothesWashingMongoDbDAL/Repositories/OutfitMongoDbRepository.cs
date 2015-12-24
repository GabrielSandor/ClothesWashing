using System.Collections.Generic;
using System.Linq;
using ClothesWashing.Clothes;
using ClothesWashing.Wearing;
using ClothesWashingMongoDbDAL.States;
using MongoDB.Driver;

namespace ClothesWashingMongoDbDAL.Repositories
{
    sealed class OutfitMongoDbRepository : IOutfitRepository
    {
        private readonly IMongoCollection<OutfitState> _outfits;
        private readonly IClothesRepository _clothesRepository;

        public OutfitMongoDbRepository(ClothesDbContext context, IClothesRepository clothesRepository)
        {
            _clothesRepository = clothesRepository;
            _outfits = context.Outfits;
        }

        public IEnumerable<Outfit> RetrieveAllOutfits()
        {
            var states = _outfits.AsQueryable().ToList();
            return states.Select(o => new Outfit(o));
        }

        public void StoreOutfit(Outfit outfit)
        {
            foreach (var clothingArticle in outfit.Clothes)
            {
                _clothesRepository.UpdateClothingArticle(clothingArticle);
            }

            var state = (OutfitState)outfit.StorageState;
            _outfits.InsertOneAsync(state).Wait();
        }
    }
}
