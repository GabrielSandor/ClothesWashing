using System;
using System.Collections.Generic;
using ClothesWashing.Services;

namespace ClothesWashingApp.Commands
{
    sealed class ShowDirtyClothesCommand : ICommand
    {
        private readonly IFindDirtyClothesService _findDirtyClothesService;

        public ShowDirtyClothesCommand(IFindDirtyClothesService findDirtyClothesService)
        {
            _findDirtyClothesService = findDirtyClothesService;
        }

        public void Execute(IEnumerable<string> arguments)
        {
            var dirtyClothes = _findDirtyClothesService.FindDirtyClothes();

            Console.WriteLine("Showing clothes that need washing:");
            foreach (var clothingArticle in dirtyClothes)
            {
                Console.WriteLine(clothingArticle);
            }
        }
    }
}
