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

        [BindProperty(SupportsGet = true)]
        public int? AdmissionStatus { get; set; } = 0;


        public async Task OnGetAsync()
        {
            ViewData["ActivePage"] = "/AdmissionView";
            Admissions = await _admissionService.SearchAdmissions(StartDate, EndDate, AdmissionStatus);
           
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