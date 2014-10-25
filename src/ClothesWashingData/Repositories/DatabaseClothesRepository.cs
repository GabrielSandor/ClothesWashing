using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ClothesWashing.Repositories;
using ClothesWashingData.DataModel;

namespace ClothesWashingData.Repositories
{
    public sealed class DatabaseClothesRepository : IClothesRepository
    {
        private readonly IDbSet<ClothingArticle> _context;

        public DatabaseClothesRepository(IDbSet<ClothingArticle> context)
        {
            _context = context;
        }

        public void AddClothingArticle(ClothesWashing.ClothingArticle clothingArticle)
        {
            _context.Add(ClothingArticle.ToDataModel(clothingArticle));
        }

        public void RemoveClothingArticle(string clothingArticleTag)
        {
            var clothingArticle = _context.Find(clothingArticleTag);
            if (clothingArticle != null)
            {
                _context.Remove(clothingArticle);
            }
        }

        public async Task<IEnumerable<ClothesWashing.ClothingArticle>> GetAllClothesAsync()
        {
            var query = from clothing in ClothingArticleQueryable(_context)
                        select clothing.ToDomainModel();

            return await query.ToListAsync();
        }

        public async Task<ClothesWashing.ClothingArticle> GetClothingArticleByTagAsync(string tag)
        {
            var query = from clothing in ClothingArticleQueryable(_context)
                        where clothing.Tag == tag
                        select clothing;

            var dbClothingArticle = await query.SingleOrDefaultAsync();

            return dbClothingArticle != null
                ? dbClothingArticle.ToDomainModel()
                : null;
        }

        static IQueryable<ClothingArticle> ClothingArticleQueryable(IQueryable<ClothingArticle> context)
        {
            return context.Include(c => c.ClothingArticleState);
        }
    }
}
