using System;

namespace ClothesWashing.Services
{
    public sealed class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow()
        {
            return DateTime.Now;
        }

        public DateTime Today()
        {
            return DateTime.Now/*.Date*/;
        }
    }
}
