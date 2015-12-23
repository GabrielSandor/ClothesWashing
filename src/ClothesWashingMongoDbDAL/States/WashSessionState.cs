using System;
using ClothesWashing.Washing;

namespace ClothesWashingMongoDbDAL.States
{
    sealed class WashSessionState : ClothesCollectionState, IWashSessionState
    {
        public int Id { get; set; }
        public DateTime WashDate { get; set; }
    }
}
