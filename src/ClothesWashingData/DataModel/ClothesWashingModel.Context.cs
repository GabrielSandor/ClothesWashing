﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClothesWashingEntities : DbContext
    {
        public ClothesWashingEntities()
            : base("name=ClothesWashingEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClothingArticle> ClothingArticles { get; set; }
        public virtual DbSet<ClothingArticleState> ClothingArticleStates { get; set; }
        public virtual DbSet<Outfit> Outfits { get; set; }
        public virtual DbSet<WashingSession> WashingSessions { get; set; }
    }
}
