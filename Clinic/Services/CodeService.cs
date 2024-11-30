using AutoMapper;
using Clinic.Data;
using Clinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class CodeService : ICodeService
    {
        private readonly ApplicationDbContext _context;

        public CodeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> GetGenders()
        {
            return await _context.Genders
                                 .Select(g => new SelectListItem
                                 {
                                     Value = g.Id.ToString(),
                                     Text = g.Name
                                 })
                                 .ToListAsync();
        }

        public async Task<List<SelectListItem>> GetTitles()
        {
            return await _context.Titles
                                 .Select(g => new SelectListItem
                                 {
                                     Value = g.Id.ToString(),
                                     Text = g.Name
                                 })
                                 .ToListAsync();
        }
    }
}