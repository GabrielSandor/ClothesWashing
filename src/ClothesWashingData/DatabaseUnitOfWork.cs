using System;
using System.Threading.Tasks;
using ClothesWashing;
using ClothesWashing.Repositories;
using ClothesWashingData.DataModel;
using ClothesWashingData.Repositories;

namespace ClothesWashingData
{
    public sealed class DatabaseUnitOfWork : IUnitOfWork
    {
        readonly ClothesWashingEntities _context;

        readonly DatabaseClothesRepository _databaseClothesRepository;
        readonly DatabaseOutfitRepository _databaseOutfitRepository;
        readonly DatabaseWashingSessionRepository _databaseWashingSessionRepository;

        bool _disposed;

        public DatabaseUnitOfWork()
        {
            _context = new ClothesWashingEntities();

            _databaseClothesRepository = new DatabaseClothesRepository(_context.ClothingArticles);
            _databaseOutfitRepository = new DatabaseOutfitRepository(_context.Outfits);
            _databaseWashingSessionRepository = new DatabaseWashingSessionRepository(_context.WashingSessions);
        }

        public IClothesRepository ClothesRepository
        {
            get { return _databaseClothesRepository; }
        }

        public IOutfitRepository OutfitRepository
        {
            get { return _databaseOutfitRepository; }
        }

        public IWashingSessionRepository WashingSessionRepository
        {
            get { return _databaseWashingSessionRepository; }
        }

        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        #region Dispose logic

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        ~DatabaseUnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}
