using System;
using ClothesWashing.Clothes;
using ClothesWashing.UnitOfWork;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;
using ClothesWashingEFCodeFirstDAL.Repositories;

namespace ClothesWashingEFCodeFirstDAL.UnitOfWork
{
    public sealed class SqlUnitOfWork : IUnitOfWork
    {
        private readonly ClothesWashingContext _clothesWashingContext;

        private bool _disposed;

        public IClothesRepository ClothesRepository { get; }
        public IWashSessionRepository WashSessionRepository { get; }
        public IOutfitRepository OutfitRepository { get; }

        public SqlUnitOfWork()
        {
            _clothesWashingContext = new ClothesWashingContext();

            ClothesRepository = new ClothesSqlRepository(_clothesWashingContext);
            OutfitRepository = new OutfitSqlRepository(_clothesWashingContext);
            WashSessionRepository = new WashSessionSqlRepository(_clothesWashingContext);
        }

        public void SaveChanges()
        {
            _clothesWashingContext.SaveChanges();
        }

        #region Disposable logic

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SqlUnitOfWork()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _clothesWashingContext.Dispose();
            }

            _disposed = true;
        }

        #endregion
    }
}
