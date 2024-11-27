using Clinic.Models.Codes;
using Clinic.Models.Identity;

namespace Clinic.Models
{
    public class Doctor
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long GenderId { get; set; }
        public string UserId { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DoctorCode { get; set; }
        public long TitleId { get; set; }
        public Gender Gender { get; set; }
        public Title Title { get; set; }
        public User User { get; set; }
        public ICollection<Admission> Admissions {  get; set; }

    }
}
