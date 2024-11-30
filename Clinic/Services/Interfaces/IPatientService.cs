using Clinic.Models;
using Clinic.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.Services.Interfaces
{
    public interface IPatientService
    {
        Task<GetPatientByIdDto> GetPatientById(long patientId);
        Task<List<GetPatientDto>> GetAllPatients();
        Task<List<SelectListItem>> GetListPatients();
        Task<long?> AddPatient(AddPatientDto addPatient);
        Task<GetPatientByIdDto> UpdatePatient(AddPatientDto updatePatient);
    }
}
