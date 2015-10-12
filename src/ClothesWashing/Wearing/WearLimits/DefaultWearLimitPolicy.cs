using System;
using System.Collections.Generic;
using ClothesWashing.Clothes;

namespace ClothesWashing.Wearing.WearLimits
{
    public sealed class DefaultWearLimitPolicy : IWearLimitPolicy
    {
        static readonly IReadOnlyDictionary<ClothingArticleType, ushort> WearLimitBeforeWash =
            new Dictionary<ClothingArticleType, ushort>
            {
                { ClothingArticleType.Blouse, 3 },
                { ClothingArticleType.Shirt, 3 },
                { ClothingArticleType.Trousers, 4 },

                { ClothingArticleType.Shorts, 4 },
                { ClothingArticleType.Tshirt, 3 },

                { ClothingArticleType.Coat, 30 },

                { ClothingArticleType.Underwear, 1 },
                { ClothingArticleType.Undershirt, 2 },
                { ClothingArticleType.Pijama, 7 },
                { ClothingArticleType.Socks, 1 },

                { ClothingArticleType.Cap, 30 },
                { ClothingArticleType.Scarf, 30 },
            };

        public ushort GetWearLimitBeforeWashing(ClothingArticleType clothingArticleType)
        {
            ushort limit;
            if (WearLimitBeforeWash.TryGetValue(clothingArticleType, out limit))
            {
                return limit;
            }

            throw new ArgumentOutOfRangeException(nameof(clothingArticleType));
        }
    }
}
