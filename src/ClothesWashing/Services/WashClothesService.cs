using System.Collections.Generic;
using ClothesWashing.Washing;

namespace ClothesWashing.Services
{
    public class WashClothesService : IWashClothesService
    {
        private readonly IWashSessionFactory _washSessionFactory;
        private readonly IWashSessionRepository _washSessionRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public WashClothesService(IWashSessionFactory washSessionFactory, IWashSessionRepository washSessionRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _washSessionFactory = washSessionFactory;
            _washSessionRepository = washSessionRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public void WashClothes(ISet<string> clothingArticledIds)
        {
            var washSession = _washSessionFactory.BuildWashSession(clothingArticledIds);

            var today = _dateTimeProvider.Today();
            washSession.Perform(today);

            _washSessionRepository.StoreWashSession(washSession);
        }
    }
}
