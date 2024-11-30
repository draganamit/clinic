namespace Clinic.Models.DTOs
{
    public class GetPatientDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string JMBG { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string GenderName {  get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
