﻿using ClothesWashing;
using ClothesWashing.Clothes;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;

namespace ClothesWashingMongoDbDAL.States
{
    public sealed class MongoDbStorageStateAbstractFactory : IStorageStateAbstractFactory
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
