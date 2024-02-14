using Appointments.Models;
using Microsoft.EntityFrameworkCore;

namespace Appointments.DataContext
{
    public class DbDataContext:DbContext
    {
        public DbDataContext(DbContextOptions<DbDataContext> options):base(options){ }

        public DbSet<AppointmentModel> Appointment { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Doctor>().Property(d => d.Name).HasMaxLength(50);
            modelBuilder.Entity<Doctor>().Property(d => d.Specialist).HasMaxLength(50);
            modelBuilder.Entity<Doctor>().Property(d => d.Phone).HasMaxLength(20);
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 11, Name = "Doctor1", Specialist = "Specialty1", Phone = "111-111-1111" },
                new Doctor { DoctorId = 12, Name = "Doctor2", Specialist = "Specialty2", Phone = "222-222-2222" },
                new Doctor { DoctorId = 13, Name = "Doctor3", Specialist = "Specialty3", Phone = "333-333-3333" },
                new Doctor { DoctorId = 14, Name = "Doctor4", Specialist = "Specialty4", Phone = "444-444-4444" },
                new Doctor { DoctorId = 15, Name = "Doctor5", Specialist = "Specialty5", Phone = "555-555-5555" },
                new Doctor { DoctorId = 16, Name = "Doctor6", Specialist = "Specialty6", Phone = "666-666-6666" },
                new Doctor { DoctorId = 17, Name = "Doctor7", Specialist = "Specialty7", Phone = "777-777-7777" },
                new Doctor { DoctorId = 18, Name = "Doctor8", Specialist = "Specialty8", Phone = "888-888-8888" },
                new Doctor { DoctorId = 19, Name = "Doctor9", Specialist = "Specialty9", Phone = "999-999-9999" },
                new Doctor { DoctorId = 20, Name = "Doctor10", Specialist = "Specialty10", Phone = "000-000-0000" }
            );
        }
    }
}
