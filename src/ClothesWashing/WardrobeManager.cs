using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesWashing.Repositories;

namespace ClothesWashing
{
    public sealed class WardrobeManager
    {
        IUnitOfWorkFactory _unitOfWorkFactory;

        public void AddNewClothingArticle(ClothingArticle clothingArticle)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.ClothesRepository.AddClothingArticle(clothingArticle);
            }
        }

        public void RemoveClothingArticle(string clothingArticleTag)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.ClothesRepository.RemoveClothingArticle(clothingArticleTag);
            }
        }

        public void InitiateWashingSession(ISet<string> clothingArticleTags)
        {

        }

        public void WearOutfit(ISet<string> clothingArticleTags)
        {

        }

    }
}
