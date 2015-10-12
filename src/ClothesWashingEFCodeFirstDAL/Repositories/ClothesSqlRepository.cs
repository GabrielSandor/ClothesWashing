using System.Collections.Generic;
using System.Data.Entity;
using ClothesWashing.Clothes;

namespace ClothesWashingEFCodeFirstDAL.Repositories
{
    public sealed class ClothesSqlRepository : IClothesRepository
    {
        private readonly ClothesWashingContext _context;

        public ClothesSqlRepository(ClothesWashingContext context)
        {
            _context = context;
        }

        public IEnumerable<ClothingArticle> RetrieveAllClothes()
        {
            return _context.Clothes;
        }

        public ClothingArticle RetrieveClothingArticleById(string id)
        {
            return _context.Clothes.Find(id);
        }

        public void StoreClothingArticle(ClothingArticle clothingArticle)
        {
            _context.Clothes.Add(clothingArticle);
        }

        public void UpdateClothingArticle(ClothingArticle clothingArticle)
        {
            _context.Entry(clothingArticle).State = EntityState.Modified;
        }

        public void RemoveClothingArticle(ClothingArticle clothingArticle)
        {
            _context.Clothes.Remove(clothingArticle);
        }
    }
}
