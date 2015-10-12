using System.Collections.Generic;

namespace ClothesWashing.Clothes
{
    public interface IClothesRepository
    {
        IEnumerable<ClothingArticle> RetrieveAllClothes();
        ClothingArticle RetrieveClothingArticleById(string id);
        void StoreClothingArticle(ClothingArticle clothingArticle);
        void UpdateClothingArticle(ClothingArticle clothingArticle);
        void RemoveClothingArticle(ClothingArticle clothingArticle);
    }
}
