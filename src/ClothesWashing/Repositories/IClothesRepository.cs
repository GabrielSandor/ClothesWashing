using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothesWashing.Repositories
{
    public interface IClothesRepository
    {
        void AddClothingArticle(ClothingArticle clothingArticle);
        void RemoveClothingArticle(string clothingArticleTag);
        Task<IEnumerable<ClothingArticle>> GetAllClothesAsync();
        Task<ClothingArticle> GetClothingArticleByTagAsync(string tag);
    }
}
