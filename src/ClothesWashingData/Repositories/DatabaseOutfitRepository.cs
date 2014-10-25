using System.Data.Entity;
using ClothesWashing.Repositories;
using ClothesWashingData.DataModel;

namespace ClothesWashingData.Repositories
{
    public sealed class DatabaseOutfitRepository : IOutfitRepository
    {
        private readonly IDbSet<Outfit> _context;

        public DatabaseOutfitRepository(IDbSet<Outfit> context)
        {
            _context = context;
        }

        public void AddOutfit(ClothesWashing.Outfit outfit)
        {
            _context.Add(Outfit.ToDataModel(outfit));
        }
    }
}
