using System;
using System.Collections.Generic;
using System.Linq;
using ClothesWashing.Clothes;

namespace ClothesWashing.Washing
{
    public sealed class WashSessionFactory : IWashSessionFactory
    {
        private readonly IClothesRepository _clothesRepository;
        private readonly IStorageStateAbstractFactory _storageStateAbstractFactory;

        public WashSessionFactory(IClothesRepository clothesRepository, IStorageStateAbstractFactory storageStateAbstractFactory)
        {
            _clothesRepository = clothesRepository;
            _storageStateAbstractFactory = storageStateAbstractFactory;
        }

        public WashSession BuildWashSession(ISet<string> clothingArticleIds)
        {
            var clothes = RetrieveClothes(clothingArticleIds);

            var state = _storageStateAbstractFactory.BuildWashSessionState();
            return new WashSession(new HashSet<ClothingArticle>(clothes), state);
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
