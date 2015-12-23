using System;
using ClothesWashing.Clothes;

namespace ClothesWashingMongoDbDAL.States
{
    sealed class ClothingArticleState : IClothingArticleState
    {
        public string Id { get; set; }
        public ClothingArticleType Type { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }

        public DateTime? PurchaseDate { get; set; }
        public DateTime? LastWashDate { get; set; }
        public DateTime? LastWearDate { get; set; }

        public ushort TimesWornSinceLastWash { get; set; }

        public bool IsDirty { get; set; }
    }
}
