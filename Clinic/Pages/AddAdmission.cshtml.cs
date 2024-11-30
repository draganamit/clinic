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

        public AddAdmissionModel(IMapper mapper, IAdmissionService admissionService, IPatientService patientService, IDoctorService doctorService)
        {
            _mapper = mapper;
            _admissionService = admissionService;
            _patientService = patientService;
            _doctorService = doctorService;
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
                GetAdmissionByIdDto admission = await _admissionService.GetAdmissionById(admissionId.Value);

                if (admission == null)
                {

                    return NotFound();
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
    }
}
