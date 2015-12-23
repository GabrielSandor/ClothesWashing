using System.Collections.Generic;
using System.Linq;
using ClothesWashing.Washing;
using ClothesWashingEFCodeFirstDAL.States;

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
            return _context.WashSessions.Select(ws => new WashSession(ws));
        }

        public void StoreWashSession(WashSession washSession)
        {
            var state = (WashSessionState)washSession.StorageState;
            _context.WashSessions.Add(state);
        }
    }
}
