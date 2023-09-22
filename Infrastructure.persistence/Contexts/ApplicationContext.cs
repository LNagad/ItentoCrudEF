using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Region > Regions { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().HasKey(p => p.Id);
            modelBuilder.Entity<PokemonType>().HasKey(p => p.Id);
            modelBuilder.Entity<Region>().HasKey(p => p.Id);

            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.Region)
                .WithMany()
                .HasForeignKey(p => p.RegionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.PrimaryType)
                .WithMany()
                .HasForeignKey(p => p.PrimaryTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.SecondaryType)
                .WithMany()
                .HasForeignKey(p => p.SecondaryTypeId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Region>()
                .HasMany(p => p.Pokemons)
                .WithOne(p => p.Region)
                .HasForeignKey(p => p.RegionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pokemon>().Property(p => p.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(p => p.PrimaryTypeId).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(p => p.SecondaryTypeId).IsRequired(false);


            modelBuilder.Entity<Pokemon>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<PokemonType>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Region>().HasIndex(p => p.Name).IsUnique();
        }
    }
}
