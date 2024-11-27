using Clinic.Models.Codes;
using Clinic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clinic.Data.Configurations;

namespace Clinic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }       
        public DbSet<Admission> Admissions { get; set; } 
        public DbSet<MedicalReport> MedicalReports { get; set; } 
        public DbSet<Gender> Genders { get; set; }       
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new AdmissionConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalReportConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }

}
