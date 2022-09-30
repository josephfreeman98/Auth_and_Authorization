using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Authentication_and_Authorization.ViewModels;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Authentication_and_Authorization.Pages {
    public class LoginModel : PageModel {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login Model { get; set; }


        public LoginModel(SignInManager<IdentityUser> signInManager) {
            this.signInManager = signInManager;
        }
        public void OnGet() {

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null) {
            if (ModelState.IsValid) {


                var identityResult = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);

                if (identityResult.Succeeded) {

                    if (returnUrl == null || returnUrl == "/") {
                        return RedirectToPage("Index");
                    } else {
                        return RedirectToPage(returnUrl);
                    }
                }

                ModelState.AddModelError("", "Username or Password incorrect");

            }

            return Page();
        }
    }
}
