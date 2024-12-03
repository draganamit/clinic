namespace Clinic.Models.DTOs
{
    public class AddAdmissionDto
    {
        public long Id { get; set; } = 0;
        public DateTime AdmissionDate { get; set; }
        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public bool IsEmergency { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public ICollection<MedicalReportDto> MedicalReports { get; set; } = new List<MedicalReportDto>();
    }
}