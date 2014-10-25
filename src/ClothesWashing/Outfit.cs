using System;
using System.Collections.Generic;
using System.Linq;

namespace ClothesWashing
{
    public sealed class Outfit
    {
        readonly ISet<ClothingArticle> _clothes;
        
        DateTime _wearDate;
        bool _worn;

        public DateTime WearDate { get { return _wearDate; } }

        public Outfit(ISet<ClothingArticle> clothingArticles)
        {
            CheckArguments(clothingArticles);

            _clothes = new HashSet<ClothingArticle>(clothingArticles);
        }        

        public ISet<ClothingArticle> GetClothingArticles()
        {
            return new HashSet<ClothingArticle>(_clothes);
        }

        public void Wear(DateTime wearDate)
        {
            if (_worn)
            {
                throw new InvalidOperationException("Outfit has already been worn.");
            }

            foreach (var clothingArticle in _clothes)
            {
                clothingArticle.Wear(wearDate);
            }

            _wearDate = wearDate;
            _worn = true;
        }

        private static void CheckArguments(IEnumerable<ClothingArticle> clothingArticles)
        {
            if (clothingArticles == null)
            {
                throw new ArgumentNullException("clothingArticles");
            }

            if (!clothingArticles.Any())
            {
                throw new ArgumentException("There must be at least one clothing article in an outfit.", "clothingArticles");
            }
        }
    }
}
