using System;
using System.Collections.Generic;
using ClothesWashing.Clothes;

namespace ClothesWashing.Washing
{
    public sealed class WashSession : ClothesCollection
    {
        protected override IClothesCollectionState ClothesStorageState
        {
            get { return StorageState; }
        }

        public IWashSessionState StorageState { get; }

        public DateTime WashDate
        {
            get { return StorageState.WashDate; }
            private set { StorageState.WashDate = value; }
        }

        public WashSession(IWashSessionState storageState)
            : base(storageState)
        {
            StorageState = storageState;
        }

        public WashSession(ISet<ClothingArticle> clothes, IWashSessionState storageState)
            : base(clothes, storageState)
        {
            StorageState = storageState;
        }

        public void Perform(DateTime washDate)
        {
            WashDate = washDate;

            foreach (var clothingArticle in Clothes)
            {
                clothingArticle.Wash(washDate);
            }
        }
    }
}
