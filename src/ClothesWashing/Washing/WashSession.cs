using System;
using System.Collections.Generic;
using ClothesWashing.Clothes;

namespace ClothesWashing.Washing
{
    public class WashSession
    {
        public int Id { get; set; }
        public DateTime WashDate { get; set; }
        public virtual ISet<ClothingArticle> Clothes { get; set; }

        public void StartWashing(DateTime washDate)
        {
            WashDate = washDate;

            foreach (var clothingArticle in Clothes)
            {
                clothingArticle.Wash(washDate);
            }
        }
    }
}
