using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesWashingData.DataModel
{
    partial class Outfit
    {
        public ClothesWashing.Outfit ToDomainModel()
        {
            var domainModelClothes = ClothingArticles.Select(c => c.ToDomainModel());
            var clothesSet = new HashSet<ClothesWashing.ClothingArticle>(domainModelClothes);

            return new ClothesWashing.Outfit(clothesSet);
        }

        public static Outfit ToDataModel(ClothesWashing.Outfit outfit)
        {
            var dataModelClothes = outfit.GetClothingArticles().Select(ClothingArticle.ToDataModel);
            var clothesCollection = new HashSet<ClothingArticle>(dataModelClothes);

            return new Outfit
            {
                ClothingArticles = clothesCollection,
                WearDate = outfit.WearDate
            };
        }
    }
}
