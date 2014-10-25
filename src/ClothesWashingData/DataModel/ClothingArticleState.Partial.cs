using ClothesWashing;

namespace ClothesWashingData.DataModel
{
    partial class ClothingArticleState
    {
        public ClothesWashing.ClothingArticleState ToDomainModel()
        {
            var prototype = new ClothingArticleStatePrototype
            {
                IsDirty = IsDirty,
                LastWashDate = LastWashDate,
                LastWearDate = LastWearDate,
                WearsSinceLastWash = (ushort)WearsSinceLastWash
            };

            return new ClothesWashing.ClothingArticleState(prototype);
        }
    }
}
