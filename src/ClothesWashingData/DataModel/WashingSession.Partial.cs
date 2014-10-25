using System.Collections.Generic;
using System.Linq;

namespace ClothesWashingData.DataModel
{
    partial class WashingSession
    {
        public ClothesWashing.WashingSession ToDomainModel()
        {
            var domainModelClothes = ClothingArticles.Select(c => c.ToDomainModel());
            var clothesSet = new HashSet<ClothesWashing.ClothingArticle>(domainModelClothes);

            return new ClothesWashing.WashingSession(clothesSet);
        }

        public static WashingSession ToDataModel(ClothesWashing.WashingSession washingSession)
        {
            var dataModelClothes = washingSession.GetClothingArticles().Select(ClothingArticle.ToDataModel);
            var clothesCollection = new HashSet<ClothingArticle>(dataModelClothes);

            return new WashingSession
            {
                ClothingArticles = clothesCollection,
                WashDate = washingSession.Date
            };
        }
    }
}
