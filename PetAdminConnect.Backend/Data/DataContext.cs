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
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<VetSpeciality> VetEspecialities { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<AppointmentData> Appointments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex(s => new { s.Name, s.CountryId }).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c => new { c.Name, c.StateId }).IsUnique();

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Specie)
                .WithMany(s => s.Pets)
                .HasForeignKey(p => p.SpecieId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Breed)
                .WithMany(b => b.Pets)
                .HasForeignKey(p => p.BreedId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VetSpeciality>()
                .HasKey(ve => new { ve.VetId, ve.SpecialityId });

            modelBuilder.Entity<VetSpeciality>()
                .HasOne(ve => ve.Vet)
                .WithMany(v => v.VetSpecialities)
                .HasForeignKey(ve => ve.VetId);

            modelBuilder.Entity<VetSpeciality>()
                .HasOne(ve => ve.Speciality)
                .WithMany(ev => ev.VetSpecialities)
                .HasForeignKey(ve => ve.SpecialityId);

            modelBuilder.Entity<AppointmentData>()
                .HasOne(a => a.Client)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<AppointmentData>()
                .HasOne(a => a.Pet)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppointmentData>()
                .HasOne(a => a.Vet)
                .WithMany(v => v.Appointments)
                .HasForeignKey(a => a.VetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
