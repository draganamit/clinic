namespace Clinic.Models
{
    public class MedicalReport
    {
        public long Id { get; set; }                       
        public long AdmissionId { get; set; }              
        public string ReportDescription { get; set; }     
        public DateTime CreatedAt { get; set; }            

        public Admission Admission { get; set; }
    }
}
