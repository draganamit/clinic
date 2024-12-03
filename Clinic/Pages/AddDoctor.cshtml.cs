using AutoMapper;
using Clinic.Data;
using Clinic.Models.DTOs;
using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinic.Services.Interfaces;
using Clinic.Services;

namespace Clinic.Pages
{
    public class AddDoctorModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ICodeService _codeService;
        private readonly IDoctorService _dctorService;

        public AddDoctorModel(IMapper mapper, ICodeService codeService, IDoctorService doctorService)
        {
            _mapper = mapper;
            _codeService = codeService;
            _dctorService = doctorService;
        }

        public IList<SelectListItem> Genders { get; set; }

        public IList<SelectListItem> Titles { get; set; }

        [BindProperty]
        public AddDoctorDto Doctor { get; set; }

        public string PageTitle { get; set; }

        public async Task<IActionResult> OnGetAsync(long? doctorId)
        {
            Genders = await _codeService.GetGenders();

            Titles = await _codeService.GetTitles();

            if (doctorId.HasValue)
            {
                GetDoctorByIdDto doctor = await _dctorService.GetDoctorById(doctorId.Value);

                if (doctor == null)
                {
                    return NotFound();
                }

                Doctor = _mapper.Map<AddDoctorDto>(doctor);
                PageTitle = "Izmjeni ljekara";
            }
            else
            {
                PageTitle = "Dodaj ljekara";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(long? doctorId)
        {

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Genders = await _codeService.GetGenders();

                Titles = await _codeService.GetTitles();
                return Page();
            }
            if (doctorId.HasValue)
            {
                Doctor.Id = doctorId.Value;
                var result = await _dctorService.UpdateDoctor(Doctor);
                if (result != null)
                {
                    return RedirectToPage("./DoctorView");
                }
                else
                {
                    return Page();
                }
            }

            else
            {
                var result = await _dctorService.AddDoctor(Doctor);

                if (result != null)
                {
                    return RedirectToPage("./DoctorView");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}