using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace ClothesWashingMongoDbDAL
{
    sealed class IntIdGenerator : IIdGenerator
    {
        private readonly GuidGenerator _guidGenerator;

        public IntIdGenerator(GuidGenerator guidGenerator)
        {
            _guidGenerator = guidGenerator;
        }

        public object GenerateId(object container, object document)
        {
            var guid = _guidGenerator.GenerateId(container, document);

            return guid.GetHashCode();
        }

        public bool IsEmpty(object id)
        {
            if (!(id is int)) return true;

            return (int)id == 0;
        }
    }
}
