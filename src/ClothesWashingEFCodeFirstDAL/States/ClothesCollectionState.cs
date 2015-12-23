using System.Collections.Generic;
using ClothesWashing.Clothes;

namespace ClothesWashingEFCodeFirstDAL.States
{
    public abstract class ClothesCollectionState : IClothesCollectionState
    {
        public IEnumerable<IClothingArticleState> Clothes
        {
            get { return new List<IClothingArticleState>(ClothesStates).AsReadOnly(); }
        }

        public ISet<ClothingArticleState> ClothesStates { get; }

        protected ClothesCollectionState()
        {
            ClothesStates = new HashSet<ClothingArticleState>();
        }

        public void AddClothingArticle(IClothingArticleState state)
        {
            ClothesStates.Add((ClothingArticleState)state);
        }
    }
}
