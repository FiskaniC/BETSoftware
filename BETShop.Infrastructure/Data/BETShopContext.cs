using BETShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BETShop.Infrastructure.Data
{
    public partial class BETShopContext : DbContext
    {
        public BETShopContext()
        {
        }

        public BETShopContext(DbContextOptions<BETShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Image);

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Price)
                     .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.Quantity)
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
