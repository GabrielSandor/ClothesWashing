using System;
using ClothesWashing.Washing;

namespace ClothesWashingEFCodeFirstDAL.States
{
    public class WashSessionState : ClothesCollectionState, IWashSessionState
    {
        public int Id { get; set; }
        public DateTime WashDate { get; set; }
    }
}
