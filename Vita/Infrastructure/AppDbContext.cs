using Microsoft.EntityFrameworkCore;
using Vita.Domain.Entities;
using Vita.Infrastructure.EntitiesConfiguration;

namespace Vita.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Attendance> Attendances { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=vitaSolution;Username=postgres;Password=123;Port=5432");
        }
    }
}
