namespace Clinic.Models.DTOs
{
    public class GetAdmissionByIdDto
    {
        public long Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public bool IsEmergency { get; set; }
        public bool IsCancelled { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public ICollection<MedicalReportDto> MedicalReports { get; set; }
    }
}