using Microsoft.EntityFrameworkCore;
using backend.Position.Module.DAL.Models;

namespace backend.Position.Module.DAL
{
    public class TypePosadDbContext : DbContext
    {
        public TypePosadDbContext(DbContextOptions<TypePosadDbContext> options) : base(options) { }

        public DbSet<TypePosad> TypePosads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypePosad>(entity => {
                entity.Property(e => e.Name).HasMaxLength(35);
                entity.Property(e => e.NameFull).HasMaxLength(100);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
