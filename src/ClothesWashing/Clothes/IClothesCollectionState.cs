using System.Collections.Generic;

namespace ClothesWashing.Clothes
{
    public interface IClothesCollectionState
    {
        IEnumerable<IClothingArticleState> Clothes { get; }
        void AddClothingArticle(IClothingArticleState state);
    }
}
