using ClothesWashing.Clothes;
using ClothesWashingMongoDbDAL.States;
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

        public IMongoCollection<ClothingArticleState> ClothingArticles
        {
            get { return _mongoDatabase.GetCollection<ClothingArticleState>("Clothes"); }
        }

        public IMongoCollection<OutfitState> Outfits
        {
            get { return _mongoDatabase.GetCollection<OutfitState>("Outfits"); }
        }

        public IMongoCollection<WashSessionState> WashSessions
        {
            get { return _mongoDatabase.GetCollection<WashSessionState>("WashSessions"); }
        }

        public ClothesDbContext(string connectionString)
        {
            var mongoClient = new MongoClient(connectionString);
            _mongoDatabase = mongoClient.GetDatabase("ClothesWashing_2");

            RegisterClassMaps();
        }

        private void RegisterClassMaps()
        {
            BsonClassMap.RegisterClassMap<ClothingArticleState>(cm =>
            {
                cm.AutoMap();

                cm.MapMember(c => c.Type).SetSerializer(new EnumSerializer<ClothingArticleType>(BsonType.String));
            });

            BsonClassMap.RegisterClassMap<ClothesCollectionState>();

            BsonClassMap.RegisterClassMap<OutfitState>(cm =>
            {
                cm.AutoMap();

                cm.MapIdMember(c => c.Id).SetIdGenerator(new IntIdGenerator(GuidGenerator.Instance));
            });

            BsonClassMap.RegisterClassMap<WashSessionState>(cm =>
            {
                cm.AutoMap();

                cm.MapIdMember(c => c.Id).SetIdGenerator(new IntIdGenerator(GuidGenerator.Instance));
            });
        }
    }
}
