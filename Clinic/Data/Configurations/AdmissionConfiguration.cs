using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Data.Configurations
{
    public class AdmissionConfiguration : IEntityTypeConfiguration<Admission>
    {
        public void Configure(EntityTypeBuilder<Admission> builder)
        {

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Admissions) 
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Doctor)
                .WithMany(d => d.Admissions)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.MedicalReports)
                .WithOne(mr => mr.Admission) 
                .HasForeignKey(mr => mr.AdmissionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(a => a.AdmissionDate)
                .IsRequired();

            builder.Property(a => a.IsEmergency)
                .IsRequired();
        }
    }
}
