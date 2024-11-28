using AutoMapper;
using Clinic.Data;
using Clinic.Models.DTOs;
using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Pages
{
    public class AddDoctorModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddDoctorModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IList<SelectListItem> Genders { get; set; }
        public IList<SelectListItem> Titles { get; set; }


        [BindProperty]
        public AddDoctorDto Doctor { get; set; }

        public async Task OnGetAsync()
        {
            Genders = await _context.Genders
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                })
                .ToListAsync();

            Titles = await _context.Titles
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

            var doctor = _mapper.Map<Doctor>(Doctor);

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./DoctorView");
        }

    }
}
