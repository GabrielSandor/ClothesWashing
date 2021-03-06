﻿using ClothesWashing.Services;
using ClothesWashing.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace ClothesWashingApp.Commands
{
    sealed class WashDirtyClothesCommand : ICommand
    {
        private readonly IFindDirtyClothesService _findDirtyClothesService;
        private readonly IWashClothesService _washClothesService;
        private readonly IUnitOfWork _unitOfWork;

        public WashDirtyClothesCommand(IFindDirtyClothesService findDirtyClothesService, IWashClothesService washClothesService, IUnitOfWork unitOfWork)
        {
            _findDirtyClothesService = findDirtyClothesService;
            _washClothesService = washClothesService;
            _unitOfWork = unitOfWork;
        }

        public void Execute(IEnumerable<string> arguments)
        {
            var clothesToWash = new HashSet<string>(arguments);

            var dirtyClothesIds = FindDirtyClothes();

            clothesToWash.UnionWith(dirtyClothesIds);

            _washClothesService.WashClothes(clothesToWash);

            _unitOfWork.SaveChanges();
        }

        private IEnumerable<string> FindDirtyClothes()
        {
            var dirtyClothes = _findDirtyClothesService.FindDirtyClothes();
            var dirtyClothesIds = new HashSet<string>(dirtyClothes.Select(c => c.Id));

            return dirtyClothesIds;
        }
    }
}
