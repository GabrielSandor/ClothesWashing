using System.Collections.Generic;

namespace ClothesWashing.Washing
{
    public interface IWashSessionRepository
    {
        IEnumerable<WashSession> RetrieveAllWashSessions();
        void StoreWashSession(WashSession washSession);
    }
}
