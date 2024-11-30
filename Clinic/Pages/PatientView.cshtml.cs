using Clinic.Data;
using Clinic.Models;
using Clinic.Models.DTOs;
using Clinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Pages
{
    public class PatientViewModel : PageModel
    {
        private readonly IPatientService _patientService;

        public PatientViewModel(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public IList<GetPatientDto> Patients { get; set; }

        public async Task OnGetAsync()
        {
            Patients = await _patientService.GetAllPatients();
        }
    }
}