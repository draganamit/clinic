using Clinic.Data;
using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Pages
{
    public class AdmissionViewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdmissionViewModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Admission> Admissions { get; set; }
        public async Task OnGetAsync()
        {
            Admissions = await _context.Admissions.Include(a => a.Patient).Include(a => a.Doctor).ToListAsync();
        }
    }
}
