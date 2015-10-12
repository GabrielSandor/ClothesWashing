using System.Collections.Generic;

namespace ClothesWashing.Wearing
{
    public interface IOutfitFactory
    {
        Outfit BuildOutfit(ISet<string> clothingArticleIds);
    }
}
