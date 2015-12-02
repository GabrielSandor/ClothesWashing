using System.Collections.Generic;
using ClothesWashing.UnitOfWork;

namespace ClothesWashingApp.Commands
{
    sealed class SetDirtyClothesCommand : ICommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public SetDirtyClothesCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Execute(IEnumerable<string> arguments)
        {
            var clothesRepository = _unitOfWork.ClothesRepository;

            foreach (var clothingArticleId in arguments)
            {
                var clothingArticle = clothesRepository.RetrieveClothingArticleById(clothingArticleId);
                clothingArticle.SetDirty();

                clothesRepository.UpdateClothingArticle(clothingArticle);
            }
        }
    }
}
