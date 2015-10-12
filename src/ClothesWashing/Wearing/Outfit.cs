using System;
using System.Collections.Generic;
using ClothesWashing.Clothes;

namespace ClothesWashing.Wearing
{
    public class Outfit
    {
        public int Id { get; set; }
        public DateTime WearDate { get; set; }
        public virtual ISet<ClothingArticle> Clothes { get; set; }

        public void StartWearing(DateTime wearDate)
        {
            WearDate = wearDate;

            foreach (var clothingArticle in Clothes)
            {
                clothingArticle.Wear(wearDate);
            }
        }
    }
}
