using System.Threading.Tasks;
using ClothesWashing.WearLimits;

namespace ClothesWashing.Repositories
{
    interface IWearLimitPolicyRepository
    {
        Task<IWearLimitPolicy> RetrieveWearLimitPolicyAsync();
    }
}
