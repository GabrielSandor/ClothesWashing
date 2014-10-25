using System.Data.Entity;
using ClothesWashing.Repositories;
using ClothesWashingData.DataModel;

namespace ClothesWashingData.Repositories
{
    public sealed class DatabaseWashingSessionRepository : IWashingSessionRepository
    {
        private readonly IDbSet<WashingSession> _context;

        public DatabaseWashingSessionRepository(IDbSet<WashingSession> context)
        {
            _context = context;
        }

        public void AddWashingSession(ClothesWashing.WashingSession washingSession)
        {
            _context.Add(WashingSession.ToDataModel(washingSession));
        }
    }
}
