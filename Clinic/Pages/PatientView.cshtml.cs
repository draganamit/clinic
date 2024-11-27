using Clinic.Data;
using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Pages
{
    public class PatientViewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PatientViewModel(ApplicationDbContext context)
        { 
            _context = context;
        }

        public IList<Patient> Patients { get; set; }
        public async Task OnGetAsync()
        {
            Patients = await _context.Patients.Include(p => p.Gender).ToListAsync();
        }
    }
}
