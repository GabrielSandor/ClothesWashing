using ClothesWashing.Clothes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

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
        }

        public IEnumerable<ClothingArticle> RetrieveAllClothes()
        {
            return _clothingArticles.AsQueryable();
        }

        public ClothingArticle RetrieveClothingArticleById(string id)
        {
            var filterDefBuilder = Builders<ClothingArticle>.Filter;
            var filter = filterDefBuilder.Eq(ca => ca.Id, id);

            return _clothingArticles.Find(filter).FirstOrDefaultAsync().Result;
        }

        public void StoreClothingArticle(ClothingArticle clothingArticle)
        {
            _clothingArticles.InsertOneAsync(clothingArticle).Wait();
        }

        public void UpdateClothingArticle(ClothingArticle clothingArticle)
        {
        }
    }
}
