using AutoMapper;
using Clinic.Data;
using Clinic.Models.DTOs;
using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinic.Enums;

namespace Clinic.Pages
{
    public class AddAdmissionModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddAdmissionModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<SelectListItem> Patients { get; set; }
        public IList<SelectListItem> Doctors { get; set; }


        [BindProperty]
        public AddAdmissionDto Admission { get; set; }

        public async Task OnGetAsync()
        {
            Patients = await _context.Patients
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = String.Concat(p.FirstName, " ", p.LastName)
                })
                .ToListAsync();

            Doctors = await _context.Doctors
                .Where(d => d.TitleId == (long)TitleEnum.Specialist)
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = String.Concat(d.FirstName, " ", d.LastName)
                })
                .ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return Page();
            }

            var admission = _mapper.Map<Admission>(Admission);

            _context.Admissions.Add(admission);
            await _context.SaveChangesAsync();

            return RedirectToPage("./AdmissionView");
        }
    }
}
