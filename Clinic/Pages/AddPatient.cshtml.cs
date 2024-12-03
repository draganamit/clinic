using AutoMapper;
using Clinic.Data;
using Clinic.Models;
using Clinic.Models.DTOs;
using Clinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Clinic.Pages
{
    public class AddPatientModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ICodeService _codeService;
        private readonly IPatientService _patientService;


        public AddPatientModel(IMapper mapper, ICodeService codeService, IPatientService patientService)
        {
            _mapper = mapper;
            _codeService = codeService;
            _patientService = patientService;
        }
        public IList<SelectListItem> Genders { get; set; }

        [BindProperty]
        public AddPatientDto Patient { get; set; }

        public string PageTitle { get; set; }

        public async Task<IActionResult> OnGetAsync(long? patientId)
        {
            Genders = await _codeService.GetGenders();
            if (patientId.HasValue)
            {
                GetPatientByIdDto patient = await _patientService.GetPatientById(patientId.Value);

                if (patient == null)
                {

                    return NotFound();
                }

                Patient = _mapper.Map<AddPatientDto>(patient);
                PageTitle = "Izmjeni pacijenta";

            }
            else
            {
                PageTitle = "Dodaj pacijenta";

            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(long? patientId)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); 
                }
                Genders = await _codeService.GetGenders();
                return Page();
            }

            if (patientId.HasValue)
            {
                Patient.Id = patientId.Value;
               var result = await _patientService.UpdatePatient(Patient);
                if (result != null)
                {
                    return RedirectToPage("./PatientView");
                }
                else
                {
                    return Page();
                }
            }

            else
            {
                var result = await _patientService.AddPatient(Patient);

                if (result != null)
                {
                    return RedirectToPage("./PatientView");
                }
                else
                {
                    return Page();
                }
            }  
        }

    }
}
