using System.Collections.Generic;
using ClothesWashing.Washing;

namespace ClothesWashingEFCodeFirstDAL.Repositories
{
    public sealed class WashSessionSqlRepository : IWashSessionRepository
    {
        private readonly ClothesWashingContext _context;

        public WashSessionSqlRepository(ClothesWashingContext context)
        {
            _context = context;
        }

        public IEnumerable<WashSession> RetrieveAllWashSessions()
        {
            return _context.WashSessions;
        }

        public void StoreWashSession(WashSession washSession)
        {
            _context.WashSessions.Add(washSession);
        }
    }
}
