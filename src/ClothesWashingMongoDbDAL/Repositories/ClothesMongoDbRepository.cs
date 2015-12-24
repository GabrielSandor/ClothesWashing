using ClothesWashing.Clothes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using ClothesWashingMongoDbDAL.States;

namespace ClothesWashingMongoDbDAL.Repositories
{
    sealed class ClothesMongoDbRepository : IClothesRepository
    {
        private readonly IMongoCollection<ClothingArticleState> _clothingArticles;

        public ClothesMongoDbRepository(ClothesDbContext clothesDbContext)
        {
            _clothingArticles = clothesDbContext.ClothingArticles;
        }

        public IEnumerable<ClothingArticle> RetrieveAllClothes()
        {
            var states = _clothingArticles.AsQueryable().ToList();
            return states.Select(c => new ClothingArticle(c));
        }

        public ClothingArticle RetrieveClothingArticleById(string id)
        {
            var filter = IdFilterDefinition(id);

            var state = _clothingArticles.Find(filter).FirstOrDefaultAsync().Result;
            if (state == null)
            {
                return null;
            }

            return new ClothingArticle(state);
        }

        public void StoreClothingArticle(ClothingArticle clothingArticle)
        {
            var state = (ClothingArticleState)clothingArticle.StorageState;

            _clothingArticles.InsertOneAsync(state).Wait();
        }

        public void UpdateClothingArticle(ClothingArticle clothingArticle)
        {
            var filter = IdFilterDefinition(clothingArticle.Id);
            var state = (ClothingArticleState)clothingArticle.StorageState;

            _clothingArticles.ReplaceOneAsync(filter, state).Wait();
        }

        public void RemoveClothingArticle(ClothingArticle clothingArticle)
        {
            var filter = IdFilterDefinition(clothingArticle.Id);

            _clothingArticles.DeleteOneAsync(filter).Wait();
        }

        private static FilterDefinition<ClothingArticleState> IdFilterDefinition(string clothingArticleId)
        {
            var filterDefBuilder = Builders<ClothingArticleState>.Filter;
            var filter = filterDefBuilder.Eq(ca => ca.Id, clothingArticleId);

            return filter;
        }
    }
}
