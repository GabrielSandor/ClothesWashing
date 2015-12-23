using System;

namespace ClothesWashing.Clothes
{
    public interface IClothingArticleState
    {
        string Id { get; set; }

        ClothingArticleType Type { get; set; }
        string Description { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
        string SerialNumber { get; set; }

        DateTime? PurchaseDate { get; set; }
        DateTime? LastWashDate { get; set; }
        DateTime? LastWearDate { get; set; }

        ushort TimesWornSinceLastWash { get; set; }

        bool IsDirty { get; set; }
    }
}
