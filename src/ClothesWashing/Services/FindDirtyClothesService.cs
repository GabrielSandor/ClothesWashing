using System.Collections.Generic;
using System.Linq;
using ClothesWashing.Clothes;
using ClothesWashing.Wearing.WearLimits;

namespace ClothesWashing.Services
{
    public sealed class FindDirtyClothesService : IFindDirtyClothesService
    {
        private readonly IClothesRepository _clothesRepository;
        private readonly IWearLimitPolicy _wearLimitPolicy;

        public FindDirtyClothesService(IClothesRepository clothesRepository, IWearLimitPolicy wearLimitPolicy)
        {
            _clothesRepository = clothesRepository;
            _wearLimitPolicy = wearLimitPolicy;
        }

        public ISet<ClothingArticle> FindDirtyClothes()
        {
            var allClothes = _clothesRepository.RetrieveAllClothes();

            return new HashSet<ClothingArticle>(allClothes.Where(NeedsWashing));
        }

        private bool NeedsWashing(ClothingArticle clothingArticle)
        {
            if (clothingArticle.IsDirty) return true;

            var wearLimitBeforeWashing = _wearLimitPolicy.GetWearLimitBeforeWashing(clothingArticle.Type);
            return clothingArticle.TimesWornSinceLastWash >= wearLimitBeforeWashing;
        }
    }
}
