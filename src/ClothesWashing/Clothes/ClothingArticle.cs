using System;

namespace ClothesWashing.Clothes
{
    public class ClothingArticle
    {
        public IClothingArticleState StorageState { get; }

        public string Id
        {
            get { return StorageState.Id; }
            private set { StorageState.Id = value; }
        }

        public ClothingArticleType Type
        {
            get { return StorageState.Type; }
            set { StorageState.Type = value; }
        }

        public string Description
        {
            get { return StorageState.Description; }
            set { StorageState.Description = value; }
        }

        public string Brand
        {
            get { return StorageState.Brand; }
            set { StorageState.Brand = value; }
        }

        public string Model
        {
            get { return StorageState.Model; }
            set { StorageState.Model = value; }
        }

        public string SerialNumber
        {
            get { return StorageState.SerialNumber; }
            set { StorageState.SerialNumber = value; }
        }

        public DateTime? PurchaseDate
        {
            get { return StorageState.PurchaseDate; }
            set { StorageState.PurchaseDate = value; }
        }

        public DateTime? LastWashDate
        {
            get { return StorageState.LastWashDate; }
            set { StorageState.LastWashDate = value; }
        }

        public DateTime? LastWearDate
        {
            get { return StorageState.LastWearDate; }
            set { StorageState.LastWearDate = value; }
        }

        public ushort TimesWornSinceLastWash
        {
            get { return StorageState.TimesWornSinceLastWash; }
            set { StorageState.TimesWornSinceLastWash = value; }
        }

        public bool IsDirty
        {
            get { return StorageState.IsDirty; }
            set { StorageState.IsDirty = value; }
        }

        public ClothingArticle(IClothingArticleState storageState)
        {
            StorageState = storageState;
        }

        public ClothingArticle(string id, IClothingArticleState storageState)
            : this(storageState)
        {
            Id = id;
        }

        public void Wash(DateTime washDate)
        {
            IsDirty = false;
            LastWashDate = washDate;
            TimesWornSinceLastWash = 0;
        }

        public void Wear(DateTime wearDate)
        {
            LastWearDate = wearDate;
            TimesWornSinceLastWash++;
        }

        public override string ToString()
        {
            return $"{Id} ({Type}, {Brand})";
        }
    }
}
