using System.Data.Entity;
using ClothesWashing.Clothes;
using ClothesWashing.Washing;
using ClothesWashing.Wearing;

namespace ClothesWashingEFCodeFirstDAL
{
    public class ClothesWashingContext : DbContext
    {
        public DbSet<ClothingArticle> Clothes { get; set; }
        public DbSet<Outfit> WearSessions { get; set; }
        public DbSet<WashSession> WashSessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WashSession>()
            .HasMany(ws => ws.Clothes)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("WashSession_Id");
                x.MapRightKey("ClothingArticle_Id");
                x.ToTable("ClothesInWashSessions");
            });

            modelBuilder.Entity<Outfit>()
            .HasMany(ws => ws.Clothes)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("WearSession_Id");
                x.MapRightKey("ClothingArticle_Id");
                x.ToTable("ClothesInWearSessions");
            });
        }
    }
}
