namespace ClothesWashingData.DataModel
{
    public partial class ClothingArticle
    {
        public ClothesWashing.ClothingArticle ToDomainModel()
        {
            var state = ClothingArticleState.ToDomainModel();
            var type = Type.ToDomainModel();

            return new ClothesWashing.ClothingArticle(Tag, type, state);
        }

        public static ClothingArticle ToDataModel(ClothesWashing.ClothingArticle clothingArticle)
        {
            var state = new ClothingArticleState
            {
                IsDirty = clothingArticle.IsDirty,
                LastWashDate = clothingArticle.LastWashDate,
                LastWearDate = clothingArticle.LastWearDate,
                WearsSinceLastWash = (short)clothingArticle.WearsSinceLastWash
            };

            return new ClothingArticle
            {
                Tag = clothingArticle.Tag,
                Type = clothingArticle.Type.ToDataModel(),
                ClothingArticleState = state,
                Name = clothingArticle.Name,
                Picture = clothingArticle.Picture,
                PurchaseDate = clothingArticle.PurchaseDate
            };
        }
    }
}
