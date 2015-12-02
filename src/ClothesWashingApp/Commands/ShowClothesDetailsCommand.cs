using System;
using System.Collections.Generic;
using ClothesWashing.Clothes;

namespace ClothesWashingApp.Commands
{
    sealed class ShowClothesDetailsCommand : ICommand
    {
        private readonly IClothesRepository _clothesRepository;

        public ShowClothesDetailsCommand(IClothesRepository clothesRepository)
        {
            _clothesRepository = clothesRepository;
        }

        public void Execute(IEnumerable<string> arguments)
        {
            foreach (var clothingArticleId in arguments)
            {
                var clothingArticle = _clothesRepository.RetrieveClothingArticleById(clothingArticleId);
                Console.WriteLine("{0} - {1}", clothingArticle, clothingArticle.Description); 
            }
        }
    }
}
