using System.Collections.Generic;
using ClothesWashing.Clothes;
using ClothesWashing.Wearing;
using MongoDB.Driver;

namespace ClothesWashingMongoDbDAL.Repositories
{
    sealed class OutfitMongoDbRepository : IOutfitRepository
    {
        private readonly IMongoCollection<Outfit> _outfits;
        private readonly IClothesRepository _clothesRepository;

        public OutfitMongoDbRepository(ClothesDbContext context, IClothesRepository clothesRepository)
        {
            _clothesRepository = clothesRepository;
            _outfits = context.Outfits;
        }

        public IEnumerable<Outfit> RetrieveAllOutfits()
        {
            return _outfits.AsQueryable();
        }

        public void StoreOutfit(Outfit outfit)
        {
            foreach (var clothingArticle in outfit.Clothes)
            {
                _clothesRepository.UpdateClothingArticle(clothingArticle);
            }

            _outfits.InsertOneAsync(outfit).Wait();
        }
    }
}
