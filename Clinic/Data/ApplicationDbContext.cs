using Clinic.Models.Codes;
using Clinic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clinic.Data.Configurations;
using Clinic.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace Clinic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
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

 
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Muško" },
                new Gender { Id = 2, Name = "Žensko" },
                new Gender { Id = 3, Name = "Ostalo" }
            );

 
            modelBuilder.Entity<Title>().HasData(
                new Title { Id = 1, Name = "Specijalista" },
                new Title { Id = 2, Name = "Specijalizant" },
                new Title { Id = 3, Name = "Medicinska sestra" }
            );

           

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    FirstName = "Aleksandar",
                    LastName = "Petrović",
                    JMBG = "0101993752010",
                    DateOfBirth = new DateTime(1975, 1, 1),
                    GenderId = 1,
                    Address = "Sarajevo, BiH",
                    PhoneNumber = "+387 61 234 567",
                    DoctorCode = "ap1",
                    TitleId = 1
                },
                new Doctor
                {
                    Id = 2,
                    FirstName = "Ivana",
                    LastName = "Marić",
                    JMBG = "0202991234123",
                    DateOfBirth = new DateTime(1975, 1, 1),
                    GenderId = 1,
                    Address = "Sarajevo, BiH",
                    PhoneNumber = "+387 61 432 123",
                    DoctorCode = "im2",
                    TitleId = 3
                },
                new Doctor
                {
                    Id = 3,
                    FirstName = "Selma",
                    LastName = "Begović",
                    JMBG = "0202991234567",
                    DateOfBirth = new DateTime(1982, 2, 2),
                    GenderId = 2,
                    Address = "Sarajevo, BiH",
                    PhoneNumber = "+387 62 345 678",
                    DoctorCode = "sb3",
                    TitleId = 2
                }
            );

            modelBuilder.Entity<Patient>().HasData(
 
                    new Patient
                    {
                        Id = 1,
                        FirstName = "Marko",
                        LastName = "Jurić",
                        JMBG = "0404993456789",
                        DateOfBirth = new DateTime(1985, 4, 4),
                        GenderId = 1,
                        Address = "Sarajevo, BiH",
                        PhoneNumber = "+387 66 234 567"
                    },
                    new Patient
                    {
                        Id = 2,
                        FirstName = "Jelena",
                        LastName = "Nikolić",
                        JMBG = "0606995678901",
                        DateOfBirth = new DateTime(1992, 6, 6),
                        GenderId = 2,
                        Address = "Sarajevo, BiH",
                        PhoneNumber = "+381 64 678 901"
                    }
                );

            modelBuilder.Entity<Admission>().HasData(
                new Admission
                {
                    Id = 1,
                    AdmissionDate = new DateTime(2023, 5, 1),
                    PatientId = 1, 
                    DoctorId = 1,
                    IsEmergency = true
                },
                new Admission
                {
                    Id = 2,
                    AdmissionDate = new DateTime(2023, 6, 10),
                    PatientId = 2, 
                    DoctorId = 3, 
                    IsEmergency = false 
                },
                new Admission
                {
                    Id = 3,
                    AdmissionDate = new DateTime(2023, 7, 15),
                    PatientId = 1, 
                    DoctorId = 1, 
                    IsEmergency = true 
                },
                new Admission
                {
                    Id = 4,
                    AdmissionDate = new DateTime(2023, 8, 20),
                    PatientId = 2, 
                    DoctorId = 2, 
                    IsEmergency = false 
                }
            );

            modelBuilder.Entity<MedicalReport>().HasData(
                new MedicalReport
                {
                    Id = 1,
                    AdmissionId = 1,
                    ReportDescription = "Pacijent je primljen u hitnoj pomoći zbog povrede na radu.",
                    CreatedAt = new DateTime(2023, 5, 1)
                },
                new MedicalReport
                {
                    Id = 2,
                    AdmissionId = 2,
                    ReportDescription = "Pacijentkinja je primljena zbog respiratornih problema.",
                    CreatedAt = new DateTime(2023, 6, 10)
                },
                new MedicalReport
                {
                    Id = 3,
                    AdmissionId = 3,
                    ReportDescription = "Pacijentkinja je primljena u hitnoj pomoći zbog akutnih bolova u stomaku.",
                    CreatedAt = new DateTime(2023, 7, 15)
                },
                new MedicalReport
                {
                    Id = 4,
                    AdmissionId = 4,
                    ReportDescription = "Pacijent je primljen zbog problema sa visokim krvnim pritiskom. Preporučena terapija i kontrola.",
                    CreatedAt = new DateTime(2023, 8, 20)
                }
            );
        }
        public static async Task Seed(UserManager<User> userManager)
        {
            var users = new List<User>
            {
            new User
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PhoneNumber = "061234567",
                LockoutEnabled = false
            },
            new User
            {
                UserName = "aleksandar.petrovic",
                NormalizedUserName = "ALEKSANDAR.PETROVIC",
                Email = "aleksandar.petrovic@example.com",
                NormalizedEmail = "ALEKSANDAR.PETROVIC@EXAMPLE.COM",
                EmailConfirmed = true,
                PhoneNumber = "061234567",
                LockoutEnabled = false
            },
            new User
            {
                UserName = "ivana.maric",
                NormalizedUserName = "IVANA.MARIC",
                Email = "ivana.maric@example.com",
                NormalizedEmail = "IVANA.MARIC@EXAMPLE.COM",
                EmailConfirmed = true,
                PhoneNumber = "061432123",
                LockoutEnabled = false
            },
            new User
            {
                UserName = "selma.begovic",
                NormalizedUserName = "SELMA.BEGOVIC",
                Email = "selma.begovic@example.com",
                NormalizedEmail = "SELMA.BEGOVIC@EXAMPLE.COM",
                EmailConfirmed = true,
                PhoneNumber = "062345678",
                LockoutEnabled = false
            },
            };

            foreach (var user in users)
            {
                if (await userManager.FindByNameAsync(user.UserName) == null)
                {
                    var result = await userManager.CreateAsync(user, "Test@123");
                    if (!result.Succeeded)
                    {
                        throw new Exception("Seeding failed for user: " + user.UserName);
                    }
                }
            }
        }
    }
}
