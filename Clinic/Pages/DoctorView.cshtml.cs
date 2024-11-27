using Clinic.Data;
using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Pages
{
    public class DoctorViewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DoctorViewModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Doctor> Doctors { get; set; }
        public async Task OnGetAsync()
        {
            Doctors = await _context.Doctors.Include(d => d.Gender).Include(d => d.Title).ToListAsync();
        }
    }
}
