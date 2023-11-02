using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Shared.Entities;

namespace PetAdminConnect.Backend.Data
{
    public class DataContext : IdentityDbContext<User>

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Specie> Species { get; set; }
        public DbSet<Breed> Breeds  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex(s => new { s.Name, s.CountryId }).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c => new { c.Name, c.StateId }).IsUnique();

        }
    }
}
