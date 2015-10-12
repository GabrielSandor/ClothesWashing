using System;

namespace ClothesWashing.Clothes
{
    public class ClothingArticle
    {
        public string Id { get; set; }

        //[Required]
        public ClothingArticleType Type { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }

        public DateTime? PurchaseDate { get; set; }
        public DateTime? LastWashDate { get; set; }
        public DateTime? LastWearDate { get; set; }

        //[Range(0, int.MaxValue)]
        public int TimesWornSinceLastWash { get; set; }

        public bool IsDirty { get; set; }

        public void Wash(DateTime washDate)
        {
            IsDirty = false;
            LastWashDate = washDate;
            TimesWornSinceLastWash = 0;
        }

        public void SetDirty()
        {
            IsDirty = true;
        }

        public void Wear(DateTime wearDate)
        {
            LastWearDate = wearDate;
            TimesWornSinceLastWash++;
        }

        public override string ToString()
        {
            return $"{Id} ({Type})";
        }
    }
}
