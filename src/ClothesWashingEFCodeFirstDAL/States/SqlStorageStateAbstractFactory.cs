using ClothesWashing;
using ClothesWashing.Clothes;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;

namespace ClothesWashingEFCodeFirstDAL.States
{
    public sealed class SqlStorageStateAbstractFactory : IStorageStateAbstractFactory
    {
        public IClothingArticleState BuildClothingArticleState()
        {
            return new ClothingArticleState();
        }

        public IWashSessionState BuildWashSessionState()
        {
            return new WashSessionState();
        }

        public IOutfitState BuildOutfitState()
        {
            return new OutfitState();
        }
    }
}
