using System.Collections.Generic;
using System.Linq;

namespace ClothesWashing.WashRules.RuleEngine
{
    sealed class WashRuleEngine : IWashRuleEngine
    {
        private readonly IEnumerable<IWashRule> _washRules;

        public WashRuleEngine(IEnumerable<IWashRule> washRules)
        {
            _washRules = washRules;
        }

        public bool NeedsWashing(ClothingArticle clothingArticle)
        {
            return _washRules.Any(wr => wr.NeedsWashing(clothingArticle));
        }
    }
}
