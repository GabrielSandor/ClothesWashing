using System;

namespace ClothesWashing.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow();
    }
}
