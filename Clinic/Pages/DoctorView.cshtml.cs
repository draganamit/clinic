using Clinic.Data;
using Clinic.Models;
using Clinic.Models.DTOs;
using Clinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Pages
{
    public class DoctorViewModel : PageModel
    {
        private readonly IDoctorService _doctorService;

        public DoctorViewModel(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        public IList<GetDoctorDto> Doctors { get; set; }
        public async Task OnGetAsync()
        {
            Doctors = await _doctorService.GetAllDoctors();
        }
    }
}
