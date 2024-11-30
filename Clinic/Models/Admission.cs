namespace Clinic.Models
{
    public class Admission
    {
        public long Id { get; set; }   
        public DateTime AdmissionDate { get; set; }    
        public long PatientId { get; set; }    
        public long DoctorId { get; set; }    
        public bool IsEmergency { get; set; }  
        public bool IsCancelled { get; set; } = false;
        public Patient Patient { get; set; } 
        public Doctor Doctor { get; set; }
        public ICollection<MedicalReport> MedicalReports { get; set; }
    }
}
