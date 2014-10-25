using System;
using System.Threading.Tasks;
using ClothesWashing.Repositories;

namespace ClothesWashing
{
    public interface IUnitOfWork : IDisposable
    {
        IClothesRepository ClothesRepository { get; }
        IOutfitRepository OutfitRepository { get; }
        IWashingSessionRepository WashingSessionRepository { get; }

        Task CommitAsync();
    }
}
