using System.Collections.Generic;
using ClothesWashing.Services;
using ClothesWashing.UnitOfWork;

namespace ClothesWashingApp.Commands
{
    sealed class WearOutfitCommand : ICommand
    {
        private readonly IWearOutfitService _wearOutfitService;
        private readonly IUnitOfWork _unitOfWork;

        public WearOutfitCommand(IUnitOfWork unitOfWork, IWearOutfitService wearOutfitService)
        {
            _unitOfWork = unitOfWork;
            _wearOutfitService = wearOutfitService;
        }

        public void Execute(IEnumerable<string> arguments)
        {
            var clothingArticleIds = new HashSet<string>(arguments);

            _wearOutfitService.WearOutfit(clothingArticleIds);

            _unitOfWork.SaveChanges();
        }
    }
}
