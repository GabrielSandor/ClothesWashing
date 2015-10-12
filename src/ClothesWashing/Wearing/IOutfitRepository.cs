using System.Collections.Generic;

namespace ClothesWashing.Wearing
{
    public interface IOutfitRepository
    {
        IEnumerable<Outfit> RetrieveAllOutfits();
        void StoreOutfit(Outfit outfit);
    }
}
