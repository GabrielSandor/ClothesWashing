using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesWashing.Repositories;
using ClothesWashing.WashRules.RuleEngine;

namespace ClothesWashing
{
    sealed class WashMonitor
    {
        readonly IWashRuleEngine _washRuleEngine;
        readonly IClothesRepository _clothesRepository;

        public WashMonitor(IWashRuleEngine washRuleEngine,
            IClothesRepository clothesRepository)
        {
            CheckArguments(washRuleEngine, clothesRepository);

            _washRuleEngine = washRuleEngine;
            _clothesRepository = clothesRepository;
        }

        private static void CheckArguments(IWashRuleEngine washRuleEngine, IClothesRepository clothesRepository)
        {
            if (washRuleEngine == null)
            {
                throw new ArgumentNullException("washRuleEngine");
            }

            if (clothesRepository == null)
            {
                throw new ArgumentNullException("clothesRepository");
            }
        }

        public async Task<IEnumerable<ClothingArticle>> GetAllClothesThatNeedWashingAsync()
        {
            var allClothes = await _clothesRepository.GetAllClothesAsync();
            return allClothes.Where(c => _washRuleEngine.NeedsWashing(c));
        }

        public async Task<bool> NeedsWashingAsync(string clothingArticleTag)
        {
            var clothingArticle = await _clothesRepository.GetClothingArticleByTagAsync(clothingArticleTag);
            if (clothingArticle == null)
            {
                var exMessage = string.Format("Clothing article with tag \"{0}\" does not exist.", clothingArticleTag);
                throw new ArgumentException(exMessage, "clothingArticleTag");
            }

            return _washRuleEngine.NeedsWashing(clothingArticle);
        }
    }
}
