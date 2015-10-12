using System.Collections.Generic;
using ClothesWashing.Wearing;

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
            return _context.WearSessions;
        }

        public void StoreOutfit(Outfit outfit)
        {
            _context.WearSessions.Add(outfit);
        }
    }
}
