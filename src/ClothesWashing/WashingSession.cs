using System;
using System.Collections.Generic;
using System.Linq;

namespace ClothesWashing
{
    public sealed class WashingSession
    {
        readonly ISet<ClothingArticle> _clothes;
        
        DateTime _washDate;
        bool _washingPerformed;

        public DateTime Date { get { return _washDate; } }

        public WashingSession(ISet<ClothingArticle> clothingArticles)
        {
            CheckArguments(clothingArticles);

            _clothes = new HashSet<ClothingArticle>(clothingArticles);
        }

        public void Wash(DateTime washDate)
        {
            if (_washingPerformed)
            {
                throw new InvalidOperationException("Washing already took place.");
            }

            foreach (var clothingArticle in _clothes)
            {
                clothingArticle.Wash(washDate);
            }

            _washDate = washDate;
            _washingPerformed = true;
        }

        public ISet<ClothingArticle> GetClothingArticles()
        {
            return new HashSet<ClothingArticle>(_clothes);
        }

        private static void CheckArguments(IEnumerable<ClothingArticle> clothingArticles)
        {
            if (clothingArticles == null)
            {
                throw new ArgumentNullException("clothingArticles");
            }

            if (!clothingArticles.Any())
            {
                throw new ArgumentException("There must be at least one clothing article in a washing session.", "clothingArticles");
            }
        }
    }
}
