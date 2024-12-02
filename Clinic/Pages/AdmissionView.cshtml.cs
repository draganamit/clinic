using Clinic.Data;
using Clinic.Models;
using Clinic.Models.DTOs;
using Clinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Pages
{
    public class AdmissionViewModel : PageModel
    {
        private readonly IAdmissionService _admissionService;

        public AdmissionViewModel(IAdmissionService admissionService)
        {
            _admissionService = admissionService;
        }

        public IList<GetAdmissionDto> Admissions { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? EndDate { get; set; }

        public async Task OnGetAsync()
        {
            if (StartDate.HasValue || EndDate.HasValue)
            {
                Admissions = await _admissionService.SearchAdmissions(StartDate, EndDate);
            }
            else
            {
                Admissions = await _admissionService.GetAllAdmissions();
            }
        }

        public async Task<IActionResult> OnPostSoftDeleteAsync(long admissionId)
        {
            var result = await _admissionService.CancelAdmission(admissionId);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                Admissions = result;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(long admissionId)
        {
            var result = await _admissionService.DeleteAdmission(admissionId);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                Admissions = result;
                return Page();
            }
        }

        public IActionResult OnPostDetails(long admissionId)
        {
            return RedirectToPage("./MedicalReportView", new { admissionId = admissionId });
        }
    }
}