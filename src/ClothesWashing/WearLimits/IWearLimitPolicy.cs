namespace ClothesWashing.WearLimits
{
    interface IWearLimitPolicy
    {
        uint GetWearLimitBeforeWashing(ClothingArticleType clothingArticleType);
    }
}
