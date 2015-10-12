using System.Collections.Generic;
using ClothesWashing.Services;
using ClothesWashing.UnitOfWork;

namespace ClothesWashingApp.Commands
{
    sealed class WashCommand : ICommand
    {
        private readonly IWashClothesService _washClothesService;
        private readonly IUnitOfWork _unitOfWork;

        public WashCommand(IWashClothesService washClothesService, IUnitOfWork unitOfWork)
        {
            _washClothesService = washClothesService;
            _unitOfWork = unitOfWork;
        }

        public void Execute(IEnumerable<string> arguments)
        {
            var clothingArticleIds = new HashSet<string>(arguments);

            _washClothesService.WashClothes(clothingArticleIds);

            _unitOfWork.SaveChanges();
        }
    }
}
