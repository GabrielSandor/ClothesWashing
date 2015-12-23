using System.Collections.Generic;
using ClothesWashing.Wearing;

namespace ClothesWashing.Services
{
    public class WearOutfitService : IWearOutfitService
    {
        private readonly IOutfitFactory _outfitFactory;
        private readonly IOutfitRepository _outfitRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public WearOutfitService(IOutfitFactory outfitFactory, IOutfitRepository outfitRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _outfitFactory = outfitFactory;
            _outfitRepository = outfitRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public void WearOutfit(ISet<string> clothingArticleIds)
        {
            var outfit = _outfitFactory.BuildOutfit(clothingArticleIds);

            var today = _dateTimeProvider.Today();
            outfit.Wear(today);

            _outfitRepository.StoreOutfit(outfit);
        }
    }
}
