﻿namespace Clinic.Models.DTOs
{
    public class AddAdmissionDto
    {
        public long Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public bool IsEmergency { get; set; }

        //public ICollection<MedicalReport> MedicalReports { get; set; }
    }
}