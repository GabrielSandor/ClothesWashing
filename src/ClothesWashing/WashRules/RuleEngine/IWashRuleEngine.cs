namespace ClothesWashing.WashRules.RuleEngine
{
    internal interface IWashRuleEngine
    {
        bool NeedsWashing(ClothingArticle clothingArticle);
    }
}