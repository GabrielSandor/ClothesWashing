using System.Data.Entity;
using ClothesWashingEFCodeFirstDAL.States;

namespace ClothesWashingEFCodeFirstDAL
{
    public class ClothesWashingContext : DbContext
    {
        public DbSet<ClothingArticleState> Clothes { get; set; }
        public DbSet<OutfitState> Outfits { get; set; }
        public DbSet<WashSessionState> WashSessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClothingArticleState>()
                .Ignore(c => c.TimesWornSinceLastWash)
                .Map(x => x.ToTable("Clothes"));

            modelBuilder.Entity<WashSessionState>()
                .Ignore(ws => ws.Clothes)
                .Map(x => x.ToTable("WashSessions"))
                .HasMany(ws => ws.ClothesStates)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("WashSession_Id");
                    x.MapRightKey("ClothingArticle_Id");
                    x.ToTable("ClothesInWashSessions");
                });

            modelBuilder.Entity<OutfitState>()
                .Ignore(ws => ws.Clothes)
                .Map(x => x.ToTable("Outfits"))
                .HasMany(ws => ws.ClothesStates)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("Outfit_Id");
                    x.MapRightKey("ClothingArticle_Id");
                    x.ToTable("ClothesInOutfits");
                });
        }
    }
}
