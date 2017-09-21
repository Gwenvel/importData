using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KraigsList.Data
{
    public partial class KraigsListContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        public KraigsListContext(DbContextOptions<KraigsListContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Ad>().ToTable("Ad");
            modelBuilder.Entity<Image>().ToTable("Image");

            // modelBuilder.Entity<Album>(entity =>
            // {
            //     entity.Property(e => e.Title)
            //         .IsRequired()
            //         .HasMaxLength(160);

            //     entity.HasOne(d => d.Artist)
            //         .WithMany(p => p.Album)
            //         .HasForeignKey(d => d.ArtistId)
            //         .OnDelete(DeleteBehavior.ClientSetNull)
            //         .HasConstraintName("FK_Album_Artist");
            // });

            // modelBuilder.Entity<Artist>(entity =>
            // {
            //     entity.Property(e => e.Name)
            //         .IsRequired()
            //         .HasMaxLength(120);
            // });
        }
    }
}
