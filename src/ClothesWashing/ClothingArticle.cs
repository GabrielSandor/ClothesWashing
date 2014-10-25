using System;

namespace ClothesWashing
{
    public sealed class ClothingArticle
    {
        readonly string _tag;
        readonly ClothingArticleType _type;
        readonly ClothingArticleState _state;

        public string Tag { get { return _tag; } }
        public ClothingArticleType Type { get { return _type; } }

        public string Name { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public byte[] Picture { get; set; }

        public bool IsDirty { get { return _state.IsDirty; } }

        public DateTime? LastWashDate { get { return _state.LastWashDate; } }

        public DateTime? LastWearDate { get { return _state.LastWearDate; } }

        public ushort WearsSinceLastWash { get { return _state.WearsSinceLastWash; } }

        public ClothingArticle(string tag, ClothingArticleType type, ClothingArticleState state)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new ArgumentException("Invalid tag.", "tag");
            }

            _tag = tag;
            _type = type;
            _state = state;
        }

        public void Wash(DateTime washDate)
        {
            _state.Wash(washDate);
        }

        public void Wear(DateTime wearDate)
        {
            _state.Wear(wearDate);
        }

        public void MakeDirty()
        {
            _state.MakeDirty();
        }
    }
}
