namespace Clinic.Models.DTOs
{
    public class GetDoctorByIdDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long GenderId { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DoctorCode { get; set; }
        public long TitleId { get; set; }
    }
}
