using System;
using ClothesWashing.Clothes;

namespace ClothesWashing.Washing
{
    public interface IWashSessionState : IClothesCollectionState
    {
        DateTime WashDate { get; set; }
    }
}
