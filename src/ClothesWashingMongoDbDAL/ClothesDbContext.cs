using ClothesWashing.Clothes;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
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

        public ClothesDbContext(string connectionString)
        {
            var mongoClient = new MongoClient(connectionString);
            _mongoDatabase = mongoClient.GetDatabase("ClothesWashing");

            RegisterClassMaps();
        }

        private void RegisterClassMaps()
        {
            BsonClassMap.RegisterClassMap<ClothingArticle>(cm =>
            {
                cm.AutoMap();

                cm.MapMember(c => c.Type).SetSerializer(new EnumSerializer<ClothingArticleType>(BsonType.String));
            });

            BsonClassMap.RegisterClassMap<Outfit>(cm =>
            {
                cm.AutoMap();

                cm.MapIdMember(c => c.Id).SetIdGenerator(new IntIdGenerator(GuidGenerator.Instance));
            });

            BsonClassMap.RegisterClassMap<WashSession>(cm =>
            {
                cm.AutoMap();

                cm.MapIdMember(c => c.Id).SetIdGenerator(new IntIdGenerator(GuidGenerator.Instance));
            });
        }
    }
}
