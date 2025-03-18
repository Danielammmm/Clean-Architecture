using FP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FP.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // 🔹 Constructor vacío requerido por `dotnet ef`
        public AppDbContext() { }

        public DbSet<FileRecord> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FileRecord>()
                .ToTable("Files")
                .HasKey(f => f.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-LIO9C0K;Database=FileProcessingDB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
    }
}
