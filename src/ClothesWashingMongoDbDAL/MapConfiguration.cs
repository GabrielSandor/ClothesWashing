using ClothesWashing.Clothes;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace ClothesWashingMongoDbDAL
{
    static class MapConfiguration
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<ClothingArticle>(cm =>
            {
                cm.AutoMap();

                cm.MapMember(c => c.Type).SetSerializer(new EnumSerializer<ClothingArticleType>(BsonType.String));

                cm.MapMember(c => c.PurchaseDate).SetSerializer(new DateTimeSerializer(dateOnly: true));
                cm.MapMember(c => c.LastWashDate).SetSerializer(new DateTimeSerializer(dateOnly: true));
                cm.MapMember(c => c.LastWearDate).SetSerializer(new DateTimeSerializer(dateOnly: true));
            });

            BsonClassMap.RegisterClassMap<Outfit>(cm =>
            {
                cm.AutoMap();

                cm.MapMember(c => c.WearDate).SetSerializer(new DateTimeSerializer(dateOnly: true));
            });

            BsonClassMap.RegisterClassMap<WashSession>(cm =>
            {
                cm.AutoMap();

                cm.MapMember(c => c.WashDate).SetSerializer(new DateTimeSerializer(dateOnly: true));
            });
        }
    }
}
