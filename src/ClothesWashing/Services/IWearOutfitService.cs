using System.Collections.Generic;

namespace ClothesWashing.Services
{
    public interface IWearOutfitService
    {
        void WearOutfit(ISet<string> clothingArticleIds);
    }
}
