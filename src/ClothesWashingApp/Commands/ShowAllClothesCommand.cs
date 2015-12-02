using System;
using System.Collections.Generic;
using ClothesWashing.Clothes;

namespace ClothesWashingApp.Commands
{
    sealed class ShowAllClothesCommand : ICommand
    {
        private readonly IClothesRepository _clothesRepository;

        public ShowAllClothesCommand(IClothesRepository clothesRepository)
        {
            _clothesRepository = clothesRepository;
        }

        public void Execute(IEnumerable<string> arguments)
        {
            var allClothes = _clothesRepository.RetrieveAllClothes();

            foreach (var clothingArticle in allClothes)
            {
                Console.WriteLine(clothingArticle);
            }
        }
    }
}
