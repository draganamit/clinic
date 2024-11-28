using AutoMapper;
using Clinic.Data;
using Clinic.Models;
using Clinic.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Clinic.Pages
{
    public class AddPatientModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddPatientModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IList<SelectListItem> Genders { get; set; }

        [BindProperty]
        public AddPatientDto Patient { get; set; }

        public async Task OnGetAsync()
        {
            Genders = await _context.Genders
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
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

            var patient = _mapper.Map<Patient>(Patient);

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./PatientView");
        }

    }
}
