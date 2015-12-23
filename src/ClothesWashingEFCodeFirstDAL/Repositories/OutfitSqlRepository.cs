using System.Collections.Generic;
using System.Linq;
using ClothesWashing.Wearing;
using ClothesWashingEFCodeFirstDAL.States;

namespace ClothesWashingEFCodeFirstDAL.Repositories
{
    public sealed class OutfitSqlRepository : IOutfitRepository
    {
        private readonly ClothesWashingContext _context;

        public OutfitSqlRepository(ClothesWashingContext context)
        {
            _context = context;
        }

        public IEnumerable<Outfit> RetrieveAllOutfits()
        {
            return _context.Outfits.Select(o => new Outfit(o));
        }

        public void StoreOutfit(Outfit outfit)
        {
            var state = (OutfitState)outfit.StorageState;
            _context.Outfits.Add(state);
        }
    }
}
