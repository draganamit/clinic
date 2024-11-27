using Clinic.Models.Codes;

namespace Clinic.Models
{
    public class Patient
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string JMBG { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public long GenderId { get; set; }
        public string? Address { get; set; }  
        public string? PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Admission> Admissions { get; set; }
    }
}
