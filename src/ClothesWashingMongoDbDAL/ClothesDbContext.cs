using ClothesWashing.Clothes;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace ClothesWashingMongoDbDAL
{
    sealed class ClothesDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public IMongoCollection<ClothingArticle> ClothingArticles
        {
            get { return _mongoDatabase.GetCollection<ClothingArticle>("Clothes"); }
        }

        public IMongoCollection<Outfit> Outfits
        {
            get { return _mongoDatabase.GetCollection<Outfit>("Outfits"); }
        }

        public IMongoCollection<WashSession> WashSessions
        {
            get { return _mongoDatabase.GetCollection<WashSession>("WashSessions"); }
        }

        public ClothesDbContext()
        {
            var mongoClient = new MongoClient();
            _mongoDatabase = mongoClient.GetDatabase("ClothesWashing");

            RegisterClassMaps();
        }

        private void RegisterClassMaps()
        {
            BsonClassMap.RegisterClassMap<ClothingArticle>(cm =>
            {
                cm.AutoMap();

                cm.MapMember(c => c.Type).SetSerializer(new EnumSerializer<ClothingArticleType>(BsonType.String));

                //cm.MapMember(c => c.PurchaseDate).SetSerializer(new DateTimeSerializer(dateOnly: true));
                //cm.MapMember(c => c.LastWashDate).SetSerializer(new DateTimeSerializer(dateOnly: true));
                //cm.MapMember(c => c.LastWearDate).SetSerializer(new DateTimeSerializer(dateOnly: true));
            });

            BsonClassMap.RegisterClassMap<Outfit>(cm =>
            {
                cm.AutoMap();

                //cm.MapMember(c => c.WearDate).SetSerializer(new DateTimeSerializer(dateOnly: true));
            });

            BsonClassMap.RegisterClassMap<WashSession>(cm =>
            {
                cm.AutoMap();

                //cm.MapMember(c => c.WashDate).SetSerializer(new DateTimeSerializer(dateOnly: true));
            });
        }
    }
}
