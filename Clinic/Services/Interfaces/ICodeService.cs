using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.Services.Interfaces
{
    public interface ICodeService
    {
        Task<List<SelectListItem>> GetGenders();
        Task<List<SelectListItem>> GetTitles();

    }
}
