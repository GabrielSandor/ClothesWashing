using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClothesWashing;
using ClothesWashing.Clothes;
using ClothesWashing.UnitOfWork;
using Newtonsoft.Json;

namespace ClothesWashingApp.Commands
{
    sealed class ImportClothesCommand : ICommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageStateAbstractFactory _storageStateAbstractFactory;

        public ImportClothesCommand(IUnitOfWork unitOfWork, IStorageStateAbstractFactory storageStateAbstractFactory)
        {
            _unitOfWork = unitOfWork;
            _storageStateAbstractFactory = storageStateAbstractFactory;
        }

        public void Execute(IEnumerable<string> arguments)
        {
            var clothes = DeserializeJsonClothingArticles(arguments);

            StoreClothes(clothes);
        }

        private List<ClothingArticle> DeserializeJsonClothingArticles(IEnumerable<string> arguments)
        {
            var jsonFilePath = arguments.FirstOrDefault();
            if (string.IsNullOrEmpty(jsonFilePath))
            {
                throw new ArgumentException("Json file path not specified.");
            }

            if (!File.Exists(jsonFilePath))
                throw new ArgumentException("Json file does not exist at the specified path.");

            var jsonInput = File.ReadAllText(jsonFilePath);

            var jsonClothesStates = JsonConvert.DeserializeObject<List<JsonClothingArticleState>>(jsonInput);
            var convertedStates = jsonClothesStates.Select(ConvertJsonToState);

            return convertedStates.Select(s => new ClothingArticle(s)).ToList();
        }

        private IClothingArticleState ConvertJsonToState(JsonClothingArticleState jsonClothingArticleState)
        {
            var state = _storageStateAbstractFactory.BuildClothingArticleState();

            state.Id = jsonClothingArticleState.Id;
            state.IsDirty = jsonClothingArticleState.IsDirty;
            state.Brand = jsonClothingArticleState.Brand;
            state.Description = jsonClothingArticleState.Description;
            state.LastWashDate = jsonClothingArticleState.LastWashDate;
            state.LastWearDate = jsonClothingArticleState.LastWearDate;
            state.Model = jsonClothingArticleState.Model;
            state.PurchaseDate = jsonClothingArticleState.PurchaseDate;
            state.SerialNumber = jsonClothingArticleState.SerialNumber;
            state.TimesWornSinceLastWash = jsonClothingArticleState.TimesWornSinceLastWash;
            state.Type = jsonClothingArticleState.Type;

            return state;
        }

        private void StoreClothes(IList<ClothingArticle> clothes)
        {
            var newClothes = clothes.Where(c => !ClothingArticleExistsInRepository(c)).ToList();

            ShowDuplicateClothes(clothes, newClothes);

            foreach (var clothingArticle in newClothes)
            {
                _unitOfWork.ClothesRepository.StoreClothingArticle(clothingArticle);
            }

            _unitOfWork.SaveChanges();
        }

        private bool ClothingArticleExistsInRepository(ClothingArticle clothingArticle)
        {
            return _unitOfWork.ClothesRepository.RetrieveClothingArticleById(clothingArticle.Id) != null;
        }

        private static void ShowDuplicateClothes(IEnumerable<ClothingArticle> clothes, IEnumerable<ClothingArticle> newClothes)
        {
            var duplicatedClothes = clothes.Except(newClothes);
            foreach (var clothingArticle in duplicatedClothes)
            {
                Console.WriteLine("Found duplicate clothing article: {0}.", clothingArticle);
            }
        }

        private sealed class JsonClothingArticleState : IClothingArticleState
        {
            public string Id { get; set; }

            public ClothingArticleType Type { get; set; }
            public string Description { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public string SerialNumber { get; set; }

            public DateTime? PurchaseDate { get; set; }
            public DateTime? LastWashDate { get; set; }
            public DateTime? LastWearDate { get; set; }

            public ushort TimesWornSinceLastWash
            {
                get { return (ushort)TimesWornSinceLastWashState; }
                set { TimesWornSinceLastWashState = (short)value; }
            }

            public short TimesWornSinceLastWashState { get; set; }

            public bool IsDirty { get; set; }
        }
    }
}
