using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VetclinicStorage.Models;

namespace VetclinicStorage
{
    public class VetclinicDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceMedicine>().HasKey(c => new { c.MedicineId, c.ServiceId });
            modelBuilder.Entity<VisitAnimal>().HasKey(c => new { c.VisitId, c.AnimalId });
            modelBuilder.Entity<VisitService>().HasKey(c => new { c.VisitId, c.ServiceId });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Vetclinic;Username=postgres;Password=postgres");
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<MedicinesDinamic> MedicinesDinamics { get; set; }
        public virtual DbSet<Recommendation> Recommendations { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<ServiceMedicine> ServiceMedicines { get; set; }
        public virtual DbSet<VisitService> VisitServices { get; set; }
        public virtual DbSet<VisitAnimal> VisitAnimals { get; set; }


    }
}
