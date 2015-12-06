using ClothesWashing.Clothes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ClothesWashingMongoDbDAL.Repositories
{
    sealed class ClothesMongoDbRepository : IClothesRepository
    {
        private readonly IMongoCollection<ClothingArticle> _clothingArticles;

        public ClothesMongoDbRepository(ClothesDbContext clothesDbContext)
        {
            _clothingArticles = clothesDbContext.ClothingArticles;
        }

        public void RemoveClothingArticle(ClothingArticle clothingArticle)
        {
            var filter = IdFilterDefinition(clothingArticle.Id);

            _clothingArticles.DeleteOneAsync(filter).Wait();
        }

        public IEnumerable<ClothingArticle> RetrieveAllClothes()
        {
            return _clothingArticles.AsQueryable();
        }

        public ClothingArticle RetrieveClothingArticleById(string id)
        {
            var filter = IdFilterDefinition(id);

            return _clothingArticles.Find(filter).FirstOrDefaultAsync().Result;
        }

        public void StoreClothingArticle(ClothingArticle clothingArticle)
        {
            _clothingArticles.InsertOneAsync(clothingArticle).Wait();
        }

        public void UpdateClothingArticle(ClothingArticle clothingArticle)
        {
            var filter = IdFilterDefinition(clothingArticle.Id);

            _clothingArticles.ReplaceOneAsync(filter, clothingArticle).Wait();
        }

        private static FilterDefinition<ClothingArticle> IdFilterDefinition(string clothingArticleId)
        {
            var filterDefBuilder = Builders<ClothingArticle>.Filter;
            var filter = filterDefBuilder.Eq(ca => ca.Id, clothingArticleId);

            return filter;
        }
    }
}
