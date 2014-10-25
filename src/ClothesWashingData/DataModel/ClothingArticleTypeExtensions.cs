using System;

namespace ClothesWashingData.DataModel
{
    static class ClothingArticleTypeExtensions
    {
        public static ClothesWashing.ClothingArticleType ToDomainModel(this ClothingArticleType type)
        {
            switch (type)
            {
                case ClothingArticleType.Blouse: return ClothesWashing.ClothingArticleType.Blouse;
                case ClothingArticleType.Shirt: return ClothesWashing.ClothingArticleType.Shirt;
                case ClothingArticleType.Trousers: return ClothesWashing.ClothingArticleType.Trousers;
                case ClothingArticleType.Shorts: return ClothesWashing.ClothingArticleType.Shorts;
                case ClothingArticleType.Tshirt: return ClothesWashing.ClothingArticleType.Tshirt;
                case ClothingArticleType.Coat: return ClothesWashing.ClothingArticleType.Coat;
                case ClothingArticleType.Underwear: return ClothesWashing.ClothingArticleType.Underwear;
                case ClothingArticleType.Undershirt: return ClothesWashing.ClothingArticleType.Undershirt;
                case ClothingArticleType.Socks: return ClothesWashing.ClothingArticleType.Socks;
                case ClothingArticleType.Cap: return ClothesWashing.ClothingArticleType.Cap;
                case ClothingArticleType.Scarf: return ClothesWashing.ClothingArticleType.Scarf;

                default: throw new ArgumentOutOfRangeException("type");
            }
        }

        public static ClothingArticleType ToDataModel(this ClothesWashing.ClothingArticleType type)
        {
            switch (type)
            {
                case ClothesWashing.ClothingArticleType.Blouse: return ClothingArticleType.Blouse;
                case ClothesWashing.ClothingArticleType.Shirt: return ClothingArticleType.Shirt;
                case ClothesWashing.ClothingArticleType.Trousers: return ClothingArticleType.Trousers;
                case ClothesWashing.ClothingArticleType.Shorts: return ClothingArticleType.Shorts;
                case ClothesWashing.ClothingArticleType.Tshirt: return ClothingArticleType.Tshirt;
                case ClothesWashing.ClothingArticleType.Coat: return ClothingArticleType.Coat;
                case ClothesWashing.ClothingArticleType.Underwear: return ClothingArticleType.Underwear;
                case ClothesWashing.ClothingArticleType.Undershirt: return ClothingArticleType.Undershirt;
                case ClothesWashing.ClothingArticleType.Socks: return ClothingArticleType.Socks;
                case ClothesWashing.ClothingArticleType.Cap: return ClothingArticleType.Cap;
                case ClothesWashing.ClothingArticleType.Scarf: return ClothingArticleType.Scarf;

                default: throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
