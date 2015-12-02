using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClothesWashing.Clothes;
using ClothesWashing.UnitOfWork;
using Newtonsoft.Json;

namespace ClothesWashingApp.Commands
{
    sealed class ImportClothesCommand : ICommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImportClothesCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Execute(IEnumerable<string> arguments)
        {
            var clothes = DeserializeJsonClothingArticles(arguments);

            StoreClothes(clothes);
        }

        private static List<ClothingArticle> DeserializeJsonClothingArticles(IEnumerable<string> arguments)
        {
            var jsonFilePath = arguments.FirstOrDefault();
            if (string.IsNullOrEmpty(jsonFilePath))
            {
                throw new ArgumentException("Json file path not specified.");
            }

            if (!File.Exists(jsonFilePath))
                throw new ArgumentException("Json file does not exist at the specified path.");

            var jsonInput = File.ReadAllText(jsonFilePath);

            var clothes = JsonConvert.DeserializeObject<List<ClothingArticle>>(jsonInput);

            return clothes;
        }

        private void StoreClothes(IList<ClothingArticle> clothes)
        {
            var newClothes = clothes.Where(c => !ClothingArticleExistsInRepository(c)).ToList();

            ShowDuplicateClothes(clothes, newClothes);

            foreach (var clothingArticle in newClothes)
            {
                _unitOfWork.ClothesRepository.StoreClothingArticle(clothingArticle);
            }

            _unitOfWork.SaveChanges();
        }

        private bool ClothingArticleExistsInRepository(ClothingArticle clothingArticle)
        {
            return _unitOfWork.ClothesRepository.RetrieveClothingArticleById(clothingArticle.Id) != null;
        }

        private static void ShowDuplicateClothes(IEnumerable<ClothingArticle> clothes, IEnumerable<ClothingArticle> newClothes)
        {
            var duplicatedClothes = clothes.Except(newClothes);
            foreach (var clothingArticle in duplicatedClothes)
            {
                Console.WriteLine("Found duplicate clothing article: {0}.", clothingArticle);
            }
        }
    }
}
