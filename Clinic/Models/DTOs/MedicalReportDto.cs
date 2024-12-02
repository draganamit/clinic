namespace Clinic.Models.DTOs
{
    public class MedicalReportDto
    {
        public long Id { get; set; }
        public long AdmissionId { get; set; }

        public string ReportDescription { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Hours { get; set; }
        public int Minutes { get; set; }
    }
}