using Clinic.Models;

namespace Clinic.Helpers
{
    public static class StringHelper
    {
        public static string DoctorCodeGenerator(string firstName, string lastName, int count)
        {
            return $"{(string.IsNullOrEmpty(firstName) ? " " :
                        firstName[0].ToString().ToUpper())}{(string.IsNullOrEmpty(lastName) ?
                        " " : lastName[0].ToString().ToUpper())}{count + 1}";
        }

        public static int GetDoctorCodeNumber(string doctorCode)
        {
            if (int.TryParse(doctorCode.Substring(2), out int number))
            {
                return number;
            }

            return 0;
        }

        public static string PatientFullNameWithJMBG(string firstName, string lastName, string JMBG)
        {
            return $"{firstName} {lastName} ({JMBG})";
        }
    }
}