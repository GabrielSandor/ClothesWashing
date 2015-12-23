using System.Collections.Generic;
using System.Linq;

namespace ClothesWashing.Clothes
{
    public abstract class ClothesCollection
    {
        protected virtual IClothesCollectionState ClothesStorageState { get; }

        public IEnumerable<ClothingArticle> Clothes
        {
            get
            {
                var clothes = ClothesStorageState.Clothes.Select(c => new ClothingArticle(c));
                return clothes.ToList().AsReadOnly();
            }
        }

        protected ClothesCollection(IClothesCollectionState clothesStorageState)
        {
            ClothesStorageState = clothesStorageState;
        }

        protected ClothesCollection(ISet<ClothingArticle> clothes, IClothesCollectionState storageState)
            : this(storageState)
        {
            foreach (var clothingArticle in clothes)
            {
                storageState.AddClothingArticle(clothingArticle.StorageState);
            }
        }
    }
}
