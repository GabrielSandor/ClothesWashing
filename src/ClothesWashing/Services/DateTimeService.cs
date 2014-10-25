using System;

namespace ClothesWashing.Services
{
    sealed class DateTimeService : IDateTimeService
    {
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
