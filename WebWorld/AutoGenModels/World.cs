// Brian Hodge
// C00170400
// CMPS 358
// Project #9

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace World
{
    public partial class World : DbContext
    {
        public World()
        {
        }

        public World(DbContextOptions<World> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Countrylanguage> Countrylanguages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Filename=..\\world.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CountryCode).HasDefaultValueSql("''");

                entity.Property(e => e.District).HasDefaultValueSql("''");

                entity.Property(e => e.Name).HasDefaultValueSql("''");

                entity.Property(e => e.Population).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Code).HasDefaultValueSql("''");

                entity.Property(e => e.Code2).HasDefaultValueSql("''");

                entity.Property(e => e.Continent).HasDefaultValueSql("'Asia'");

                entity.Property(e => e.GovernmentForm).HasDefaultValueSql("''");

                entity.Property(e => e.LocalName).HasDefaultValueSql("''");

                entity.Property(e => e.Name).HasDefaultValueSql("''");

                entity.Property(e => e.Population).HasDefaultValueSql("'0'");

                entity.Property(e => e.Region).HasDefaultValueSql("''");

                entity.Property(e => e.SurfaceArea).HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<Countrylanguage>(entity =>
            {
                entity.HasKey(e => new { e.CountryCode, e.Language });

                entity.Property(e => e.CountryCode).HasDefaultValueSql("''");

                entity.Property(e => e.Language).HasDefaultValueSql("''");

                entity.Property(e => e.IsOfficial).HasDefaultValueSql("'F'");

                entity.Property(e => e.Percentage).HasDefaultValueSql("'0.0'");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Countrylanguages)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
