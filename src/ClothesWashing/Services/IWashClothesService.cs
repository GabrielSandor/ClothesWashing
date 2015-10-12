using System.Collections.Generic;

namespace ClothesWashing.Services
{
    public interface IWashClothesService
    {
        void WashClothes(ISet<string> clothingArticledIds);
    }
}
