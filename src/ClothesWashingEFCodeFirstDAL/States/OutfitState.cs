using System;
using ClothesWashing.Wearing;

namespace ClothesWashingEFCodeFirstDAL.States
{
    public class OutfitState : ClothesCollectionState, IOutfitState
    {
        public int Id { get; set; }
        public DateTime WearDate { get; set; }
    }
}
