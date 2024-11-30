using Clinic.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<GetDoctorByIdDto> GetDoctorById(long doctorId);
        Task<List<GetDoctorDto>> GetAllDoctors();
        Task<List<SelectListItem>> GetListDoctors();
        Task<long?> AddDoctor(AddDoctorDto addDoctor);
        Task<GetDoctorByIdDto> UpdateDoctor(AddDoctorDto updateDoctor);
    }
}
