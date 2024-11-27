using Clinic.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginModel(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public Credentials Credentials { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            var user = await _userManager.FindByNameAsync(Credentials.Username);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, Credentials.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Index"); 
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt."); 
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt."); 
            return Page();
        }
    }

    public class Credentials
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


    }
}
