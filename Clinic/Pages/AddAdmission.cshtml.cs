using AutoMapper;
using Clinic.Data;
using Clinic.Models.DTOs;
using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinic.Enums;
using Clinic.Services.Interfaces;
using Clinic.Services;

namespace Clinic.Pages
{
    public class AddAdmissionModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IAdmissionService _admissionService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IMedicalReportService _medicalReportService;

        public AddAdmissionModel
            (
                IMapper mapper,
                IAdmissionService admissionService,
                IPatientService patientService, IDoctorService doctorService,
                IMedicalReportService medicalReportService
            )
        {
            _mapper = mapper;
            _admissionService = admissionService;
            _patientService = patientService;
            _doctorService = doctorService;
            _medicalReportService = medicalReportService;
        }

        public IList<SelectListItem> Patients { get; set; }
        public IList<SelectListItem> Doctors { get; set; }

        [BindProperty]
        public AddAdmissionDto Admission { get; set; }

        public string PageTitle { get; set; }
        public string ButtonText { get; set; }

        public async Task<IActionResult> OnGetAsync(long? admissionId)
        {
            Patients = await _patientService.GetListPatients();

            Doctors = await _doctorService.GetListDoctors();

            if (admissionId.HasValue)
            {
                ViewData["AdmissionId"] = admissionId.Value;
                GetAdmissionByIdDto admission = await _admissionService.GetAdmissionById(admissionId.Value);

                if (admission == null)
                {
                    throw new Exception("Admission podaci nisu prona?eni.");
                    //return NotFound();
                }
                if (admission.MedicalReports == null)
                {
                    admission.MedicalReports = new List<MedicalReport>();
                }

                Admission = _mapper.Map<AddAdmissionDto>(admission);
                PageTitle = "Izmjeni prijem";
                ButtonText = "Izmjeni";
            }
            else
            {
                PageTitle = "Dodaj prijem";
                ButtonText = "Dodaj";
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

                return Page();
            }

            if (admissionId.HasValue)
            {
                Admission.Id = admissionId.Value;
                var result = await _admissionService.UpdateAdmission(Admission);
                if (result != null)
                {
                    return RedirectToPage("./AddAdmission", new { admissionId = result.Id });
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                var result = await _admissionService.AddAdmission(Admission);

                if (result != null)
                {
                    return RedirectToPage("./AdmissionView");
                }
                else
                {
                    return Page();
                }
            }
        }

        public async Task<IActionResult> OnPostAddMedicalReport(long admissionId, [FromBody] MedicallReportDto medicallReport)
        {
            MedicallReportDto report = medicallReport.Id > 0 ?
            await _medicalReportService.UpdateMedicalReport(medicallReport) :
            await _medicalReportService.AddMedicalReport(medicallReport);

            return new JsonResult(new
            {
                success = true,
                updatedReport = report
            });
        }

        public async Task<IActionResult> OnPostRemoveMedicalReport(long admissionId, long id)
        {
            long report = await _medicalReportService.DeleteMedicalReport(id);

            return new JsonResult(new
            {
                success = true,
                id = id
            });
        }
    }
}