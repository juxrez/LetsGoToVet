using LetsGoToVet.Domain;
using Microsoft.EntityFrameworkCore;

namespace LetsGoToVet.Persistence
{
    public class LetsGoToVetDbContext : DbContext
    {
#pragma warning disable CS8618
        public LetsGoToVetDbContext(DbContextOptions<LetsGoToVetDbContext> options) :base(options)
        {
            
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Veterinary> Veterinaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasData(
                new Pet[]
                {
                    new()
                    {
                        Id = 1,
                        Name = "Astro",
                    }
                });

            modelBuilder.Entity<Veterinary>().HasData(
                new Veterinary[]
                {
                    new()
                    {
                        Id = 1,
                        Name = "Arana Pet"
                    }
                });
        }
    }
}
