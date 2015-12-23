using ClothesWashing.Clothes;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;

namespace ClothesWashing
{
    public interface IStorageStateAbstractFactory
    {
        IClothingArticleState BuildClothingArticleState();
        IWashSessionState BuildWashSessionState();
        IOutfitState BuildOutfitState();
    }
}
