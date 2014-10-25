namespace ClothesWashing.WashRules
{
    sealed class DirtyClothingWashRule : IWashRule
    {
        public bool NeedsWashing(ClothingArticle clothingArticle)
        {
            return clothingArticle.IsDirty;
        }
    }
}
