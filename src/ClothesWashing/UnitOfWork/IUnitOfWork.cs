using System;
using ClothesWashing.Clothes;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;

namespace ClothesWashing.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IClothesRepository ClothesRepository { get; }
        IWashSessionRepository WashSessionRepository { get; }
        IOutfitRepository OutfitRepository { get; }

        void SaveChanges();
    }
}
