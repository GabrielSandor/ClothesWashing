using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ClothesWashing.Clothes;
using ClothesWashingEFCodeFirstDAL.States;

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
            return _context.Clothes.ToList().Select(c => new ClothingArticle(c));
        }

        public ClothingArticle RetrieveClothingArticleById(string id)
        {
            var state = _context.Clothes.Find(id);
            if (state == null)
            {
                return null;
            }

            return new ClothingArticle(state);
        }

        public void StoreClothingArticle(ClothingArticle clothingArticle)
        {
            var state = (ClothingArticleState)clothingArticle.StorageState;

            _context.Clothes.Add(state);
        }

        public void UpdateClothingArticle(ClothingArticle clothingArticle)
        {
            var state = (ClothingArticleState)clothingArticle.StorageState;

            _context.Entry(state).State = EntityState.Modified;
        }

        public void RemoveClothingArticle(ClothingArticle clothingArticle)
        {
            var state = _context.Clothes.Find(clothingArticle.Id);

            _context.Clothes.Remove(state);
        }
    }
}
