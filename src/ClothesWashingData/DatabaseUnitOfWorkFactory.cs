using ClothesWashing;

namespace ClothesWashingData
{
    public sealed class DatabaseUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork CreateUnitOfWork()
        {
            return new DatabaseUnitOfWork();
        }
    }
}
