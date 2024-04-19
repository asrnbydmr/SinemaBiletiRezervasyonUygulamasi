using AsrınBaydemir.Models;
using Microsoft.EntityFrameworkCore;

namespace AsrınBaydemir
{
    public partial class EntityAyar : DbContext
    {
        public virtual DbSet<Film> Film { get; set; }

        public virtual DbSet<Salon> Salon { get; set; }

        public virtual DbSet<Seans> Seans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=AsrınBaydemir.db");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("Film");
                entity.HasKey(e => e.id);
                entity.Property(e => e.FilmAd).HasColumnType("TEXT");
                entity.Property(e => e.FilmTarih).HasColumnType("DATETIME");
                entity.Property(e => e.Saat1).HasColumnType("TIMESPAN");
                entity.Property(e => e.Saat2).HasColumnType("TIMESPAN");
                entity.Property(e => e.Saat3).HasColumnType("TIMESPAN");
                entity.Property(e => e.Saat4).HasColumnType("TIMESPAN");
                entity.Property(e => e.Saat5).HasColumnType("TIMESPAN");
                entity.Property(e => e.Saat6).HasColumnType("TIMESPAN");
            });
            modelBuilder.Entity<Salon>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.SalonAd).HasColumnType("TEXT");
                entity.Property(e => e.Kapasite).HasColumnType("INTEGER");
            });
            modelBuilder.Entity<Seans>(entity => {
                entity.HasKey(e => e.id);
                entity.Property(e => e.FilmAd).HasColumnType("TEXT");
                entity.Property(e => e.FilmTarih).HasColumnType("DATETIME");
                entity.Property(e => e.FilmSaat).HasColumnType("TIMESPAN");
                entity.Property(e => e.FilmSalon).HasColumnType("TEXT");
                entity.Property(e => e.MusteriAd).HasColumnType("TEXT");
                entity.Property(e => e.TCKimlikNo).HasColumnType("TEXT");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
