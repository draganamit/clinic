using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Data.Configurations
{
    public class MedicalReportConfiguration : IEntityTypeConfiguration<MedicalReport>
    {
        public void Configure(EntityTypeBuilder<MedicalReport> builder)
        {
            builder.HasOne(mr => mr.Admission)
                .WithMany(a => a.MedicalReports) 
                .HasForeignKey(mr => mr.AdmissionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(mr => mr.ReportDescription)
                .IsRequired();  

            builder.Property(mr => mr.CreatedAt)
                .IsRequired();  
        }
    }
    
}
