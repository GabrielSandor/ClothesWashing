using System;
using ClothesWashing.Wearing;

namespace ClothesWashingMongoDbDAL.States
{
    sealed class OutfitState : ClothesCollectionState, IOutfitState
    {
        public int Id { get; set; }
        public DateTime WearDate { get; set; }
    }
}
