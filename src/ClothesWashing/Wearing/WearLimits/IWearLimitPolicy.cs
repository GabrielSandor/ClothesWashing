using ClothesWashing.Clothes;

namespace ClothesWashing.Wearing.WearLimits
{
    public interface IWearLimitPolicy
    {
        ushort GetWearLimitBeforeWashing(ClothingArticleType clothingArticleType);
    }
}
