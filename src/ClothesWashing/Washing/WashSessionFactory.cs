using System;
using System.Collections.Generic;
using System.Linq;
using ClothesWashing.Clothes;

namespace ClothesWashing.Washing
{
    public sealed class WashSessionFactory : IWashSessionFactory
    {
        private readonly IClothesRepository _clothesRepository;

        public WashSessionFactory(IClothesRepository clothesRepository)
        {
            _clothesRepository = clothesRepository;
        }

        public WashSession BuildWashSession(ISet<string> clothingArticleIds)
        {
            var clothes = RetrieveClothes(clothingArticleIds);

            return new WashSession
            {
                Clothes = new HashSet<ClothingArticle>(clothes)
            };
        }

        IEnumerable<ClothingArticle> RetrieveClothes(IEnumerable<string> clothingArticleIds)
        {
            return clothingArticleIds.Select(RetrieveClothingArticle);
        }

        private ClothingArticle RetrieveClothingArticle(string clothingArticleId)
        {
            var clothingArticle = _clothesRepository.RetrieveClothingArticleById(clothingArticleId);

            if (clothingArticle == null)
            {
                throw new ArgumentException($"No clothing article exists for ID {clothingArticleId}.");
            }

            return clothingArticle;
        }
    }
}
