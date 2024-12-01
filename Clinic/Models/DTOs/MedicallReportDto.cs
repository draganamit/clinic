using System.Text.Json.Serialization;

namespace Clinic.Models.DTOs
{
    public class MedicallReportDto
    {
        public long Id { get; set; }
        public long AdmissionId { get; set; }
        [JsonPropertyName("reportDescription")]
        public string ReportDescription { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}