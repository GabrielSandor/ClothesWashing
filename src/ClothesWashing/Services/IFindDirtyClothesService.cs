using System.Collections.Generic;
using ClothesWashing.Clothes;

namespace ClothesWashing.Services
{
    public interface IFindDirtyClothesService
    {
        ISet<ClothingArticle> FindDirtyClothes();
    }
}
