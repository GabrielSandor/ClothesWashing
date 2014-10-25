using System;
using ClothesWashing.WearLimits;

namespace ClothesWashing.WashRules
{
    sealed class WornClothingWashRule : IWashRule
    {
        readonly IWearLimitPolicy _wearLimitPolicy;

        public WornClothingWashRule(IWearLimitPolicy wearLimitPolicy)
        {
            if (wearLimitPolicy == null)
            {
                throw new ArgumentNullException("wearLimitPolicy");
            }

            _wearLimitPolicy = wearLimitPolicy;
        }

        private static void CheckArguments(IWearLimitPolicy wearLimitPolicy)
        {
            if (wearLimitPolicy == null)
            {
                throw new ArgumentNullException("wearLimitPolicy");
            }
        }

        public bool NeedsWashing(ClothingArticle clothingArticle)
        {
            var maximumWearsBeforeWash = _wearLimitPolicy.GetWearLimitBeforeWashing(clothingArticle.Type);

            return clothingArticle.WearsSinceLastWash >= maximumWearsBeforeWash;
        }
    }
}
