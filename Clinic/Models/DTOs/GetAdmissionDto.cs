namespace Clinic.Models.DTOs
{
    public class GetAdmissionDto
    {
        public long Id { get; set; }
        public string AdmissionDate { get; set; }
        public bool IsEmergency { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public bool IsCancelled { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public ICollection<MedicalReport> MedicalReports { get; set; }
    }
}