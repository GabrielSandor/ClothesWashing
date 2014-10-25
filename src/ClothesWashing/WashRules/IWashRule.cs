namespace ClothesWashing.WashRules
{
    interface IWashRule
    {
        bool NeedsWashing(ClothingArticle clothingArticle);
    }
}
