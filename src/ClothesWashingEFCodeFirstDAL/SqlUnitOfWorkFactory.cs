using ClothesWashing.UnitOfWork;
using ClothesWashingEFCodeFirstDAL.UnitOfWork;

namespace ClothesWashingEFCodeFirstDAL
{
    public sealed class SqlUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _connectionString;

        public SqlUnitOfWorkFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new SqlUnitOfWork(_connectionString);
        }
    }
}
