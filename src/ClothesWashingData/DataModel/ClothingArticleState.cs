//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClothesWashingData.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClothingArticleState
    {
        public ClothingArticleState()
        {
            this.ClothingArticles = new HashSet<ClothingArticle>();
        }
    
        public int Id { get; set; }
        public bool IsDirty { get; set; }
        public Nullable<System.DateTime> LastWashDate { get; set; }
        public Nullable<System.DateTime> LastWearDate { get; set; }
        public short WearsSinceLastWash { get; set; }
    
        public virtual ICollection<ClothingArticle> ClothingArticles { get; set; }
    }
}
