using System;

namespace ClothesWashing
{
    public sealed class ClothingArticleState
    {
        public bool IsDirty { get; private set; }

        public DateTime? LastWashDate { get; private set; }

        public DateTime? LastWearDate { get; private set; }

        public ushort WearsSinceLastWash { get; private set; }

        public ClothingArticleState(ClothingArticleStatePrototype prototype)
        {
            IsDirty = prototype.IsDirty;
            LastWashDate = prototype.LastWashDate;
            LastWearDate = prototype.LastWearDate;
            WearsSinceLastWash = prototype.WearsSinceLastWash;
        }

        public void Wash(DateTime washDate)
        {
            LastWashDate = washDate;
            IsDirty = false;
            WearsSinceLastWash = 0;
        }

        public void Wear(DateTime wearDate)
        {
            LastWearDate = wearDate;
            WearsSinceLastWash++;
        }

        public void MakeDirty()
        {
            IsDirty = true;
        }
    }

    public sealed class ClothingArticleStatePrototype
    {
        public bool IsDirty { get; set; }

        public DateTime? LastWashDate { get; set; }

        public DateTime? LastWearDate { get; set; }

        public ushort WearsSinceLastWash { get; set; }
    }
}
