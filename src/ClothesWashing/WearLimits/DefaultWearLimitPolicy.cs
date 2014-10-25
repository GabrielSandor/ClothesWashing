using System;
using System.Collections.Generic;

namespace ClothesWashing.WearLimits
{
    public sealed class DefaultWearLimitPolicy : IWearLimitPolicy
    {
        static readonly IDictionary<ClothingArticleType, uint> WearLimitBeforeWash =
            new Dictionary<ClothingArticleType, uint>
            {
                { ClothingArticleType.Blouse, 3 },
                { ClothingArticleType.Shirt, 3 },
                { ClothingArticleType.Trousers, 4 },
                
                { ClothingArticleType.Shorts, 4 },
                { ClothingArticleType.Tshirt, 3 },

                { ClothingArticleType.Coat, 30 },

                { ClothingArticleType.Underwear, 1 },
                { ClothingArticleType.Undershirt, 2 },
                { ClothingArticleType.Socks, 1 },

                { ClothingArticleType.Cap, 30 },
                { ClothingArticleType.Scarf, 30 },
            };

        public uint GetWearLimitBeforeWashing(ClothingArticleType clothingArticleType)
        {
            uint limit;
            if (WearLimitBeforeWash.TryGetValue(clothingArticleType, out limit))
            {
                return limit;
            }

            throw new ArgumentOutOfRangeException("clothingArticleType");
        }
    }
}
