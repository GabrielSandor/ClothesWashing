using ClothesWashing.Wearing.WearLimits;
using System;
using System.Collections.Generic;
using ClothesWashing.Clothes;
using Newtonsoft.Json;
using System.IO;

namespace ClothesWashingApp
{
    sealed class JsonWearLimitPolicy : IWearLimitPolicy
    {
        private readonly string _jsonFilePath;

        IReadOnlyDictionary<ClothingArticleType, ushort> _wearLimitsBeforeWashing;

        public JsonWearLimitPolicy(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public ushort GetWearLimitBeforeWashing(ClothingArticleType clothingArticleType)
        {
            LazyLoadWearLimits();

            ushort limit;
            if (_wearLimitsBeforeWashing.TryGetValue(clothingArticleType, out limit))
            {
                return limit;
            }

            throw new ArgumentOutOfRangeException(nameof(clothingArticleType));
        }

        private void LazyLoadWearLimits()
        {
            if (_wearLimitsBeforeWashing != null) return;

            var jsonContent = File.ReadAllText(_jsonFilePath);
            _wearLimitsBeforeWashing = JsonConvert.DeserializeObject<IReadOnlyDictionary<ClothingArticleType, ushort>>(jsonContent);
        }
    }
}
