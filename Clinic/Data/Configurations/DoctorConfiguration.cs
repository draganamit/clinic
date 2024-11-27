using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Data.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {

            builder.HasOne(d => d.Gender)
                .WithMany()
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Title)
                .WithMany() 
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.Restrict); 


            builder.HasMany(d => d.Admissions)
                .WithOne(a => a.Doctor) 
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(d => d.FirstName)
                .IsRequired(); 

            builder.Property(d => d.LastName)
                .IsRequired();

            builder.Property(d => d.JMBG)
                .IsRequired();

            builder.Property(d => d.DateOfBirth)
                .IsRequired(); 

            builder.Property(d => d.DoctorCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Address)
                .HasMaxLength(255);  

            builder.Property(d => d.PhoneNumber)
                .HasMaxLength(15); 
        }
    }
    
}
