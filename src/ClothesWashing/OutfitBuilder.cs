using System;
using System.Collections.Generic;

namespace ClothesWashing
{
    sealed class OutfitBuilder
    {
        readonly ISet<ClothingArticle> _clothingArticles;

        public OutfitBuilder()
        {
            _clothingArticles = new HashSet<ClothingArticle>();
        }

        public static OutfitBuilder CreateBuilder()
        {
            return new OutfitBuilder();
        }

        public OutfitBuilder AddClothingArticle(ClothingArticle clothingArticle)
        {
            if (_clothingArticles.Contains(clothingArticle))
            {
                throw new InvalidOperationException("Can not add the same clothing article multiple times to the same outfit.");
            }

            _clothingArticles.Add(clothingArticle);

            return this;
        }

        public Outfit Build()
        {
            var clothingArticles = new HashSet<ClothingArticle>(_clothingArticles);
            _clothingArticles.Clear();

            return new Outfit(clothingArticles);
        }
    }
}
