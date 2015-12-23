using System;
using ClothesWashing.Clothes;

namespace ClothesWashing.Wearing
{
    public interface IOutfitState : IClothesCollectionState
    {
        DateTime WearDate { get; set; }
    }
}
