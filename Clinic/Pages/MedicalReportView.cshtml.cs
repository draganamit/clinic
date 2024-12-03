using AutoMapper;
using Clinic.Models;
using Clinic.Models.DTOs;
using Clinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Composition;

namespace Clinic.Pages
{
    public class MedicalReporViewModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IAdmissionService _admissionService;
        private readonly IMedicalReportService _medicalReportService;

        public MedicalReporViewModel(IMapper mapper, IAdmissionService admissionService, IMedicalReportService medicalReportService)
        {
            _mapper = mapper;
            _admissionService = admissionService;
            _medicalReportService = medicalReportService;
        }

        public GetAdmissionDto Details { get; set; }

        [BindProperty]
        public MedicalReportDto NewMedicalReport { get; set; }

        [BindProperty]
        public ICollection<MedicalReportDto> MedicalReports { get; set; } = new List<MedicalReportDto>();

        public async Task<IActionResult> OnPostEditAsync(long admissionId, [FromBody] MedicalReportDto report)
        {
            try
            {
                MedicalReportDto response = await _medicalReportService.UpdateMedicalReport(report);

                return new JsonResult(new { success = true, message = "Uspješno sačuvano." });
            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = e.Message });
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(long admissionId, long reportId)
        {
            try
            {
                long response = await _medicalReportService.DeleteMedicalReport(reportId);

                return new JsonResult(new { success = true, message = "Uspješno sačuvano." });
            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = e.Message });
            }
        }

        public async Task<IActionResult> OnGetAsync(long? admissionId)
        {

            NewMedicalReport = new MedicalReportDto
            {
                AdmissionId=admissionId ?? 0,
                CreatedAt=DateTime.Now,
                Hours= 0,
                Minutes= 0,
                Id=0,
                ReportDescription = ""
            };
            if (admissionId > 0)
            {
                Details = await _admissionService.GetAdmissionDetailsById((long)admissionId);
                MedicalReports = await _medicalReportService.GetAllMedicalReportsForAdmission((long)admissionId);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? admissionId)
        {

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                if (admissionId > 0)
                {
                    Details = await _admissionService.GetAdmissionDetailsById((long)admissionId);
                    MedicalReports = await _medicalReportService.GetAllMedicalReportsForAdmission((long)admissionId);
                }
                return Page();
            }

            await _medicalReportService.AddMedicalReport(NewMedicalReport);

            return RedirectToPage("/MedicalReportView", new { admissionId });
        }
    }
}