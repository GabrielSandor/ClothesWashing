using System;
using System.Collections.Generic;
using ClothesWashing.Clothes;

namespace ClothesWashing.Wearing
{
    public sealed class Outfit : ClothesCollection
    {
        protected override IClothesCollectionState ClothesStorageState
        {
            get { return StorageState; }
        }

        public IOutfitState StorageState { get; }

        public DateTime WearDate
        {
            get { return StorageState.WearDate; }
            private set { StorageState.WearDate = value; }
        }

        public Outfit(IOutfitState storageState)
            : base(storageState)
        {
            StorageState = storageState;
        }

        public Outfit(ISet<ClothingArticle> clothes, IOutfitState storageState)
            : base(clothes, storageState)
        {
            StorageState = storageState;
        }

        public void Wear(DateTime wearDate)
        {
            WearDate = wearDate;

            foreach (var clothingArticle in Clothes)
            {
                clothingArticle.Wear(wearDate);
            }
        }
    }
}
