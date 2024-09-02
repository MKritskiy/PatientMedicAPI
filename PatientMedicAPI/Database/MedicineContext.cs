using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.Database
{
    public class MedicineContext : DbContext
    {
        public static string? ConnectionString { get; set; } = null;
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public MedicineContext(DbContextOptions<MedicineContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public MedicineContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cabinet>().HasData(
                new Cabinet { CabinetId = 1, CabinetNumber = 101 },
                new Cabinet { CabinetId = 2, CabinetNumber = 102 }
            );


            modelBuilder.Entity<Section>().HasData(
                new Section { SectionId = 1, SectionNumber = 1 },
                new Section { SectionId = 2, SectionNumber = 2 },
                new Section { SectionId = 3, SectionNumber = 4 }
            );


            modelBuilder.Entity<Specialization>().HasData(
                new Specialization { SpecializationId = 1, SpecializationName = "Cardiology" },
                new Specialization { SpecializationId = 2, SpecializationName = "Neurology" }
            );


            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    PatientId = 1,
                    PatientLastName = "Smith",
                    PatientFirstName = "John",
                    PatientPatronymic = "Alex",
                    PatientAddress = "123 Elm Street",
                    PatientBirthday = new DateTime(1985, 5, 15),
                    PatientGender = "Male",
                    SectionId = 1
                },
                new Patient
                {
                    PatientId = 2,
                    PatientLastName = "Doe",
                    PatientFirstName = "Jane",
                    PatientPatronymic = "Marie",
                    PatientAddress = "456 Oak Avenue",
                    PatientBirthday = new DateTime(1990, 8, 25),
                    PatientGender = "Female",
                    SectionId = 2
                }

            );

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (ConnectionString==null)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
                ConnectionString = configuration.GetConnectionString("ConnectionString");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            else
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }

        }
    }
}
