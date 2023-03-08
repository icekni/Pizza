using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RestoPizza.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public bool displayFlashMessage = false;
        IConfiguration configuration;

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Pizzas");
            }

            displayFlashMessage = false;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string username, string password, string ReturnUrl) 
        { 
            if (username == configuration.GetSection("Auth")["AdminLogin"] && password == configuration.GetSection("Auth")["AdminPassword"])
            {
                var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, username)
                    };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                displayFlashMessage = false;

                return Redirect(ReturnUrl ?? "/Admin/Pizzas");
            }

            displayFlashMessage = true;
            return Page();

        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/Admin");
        }
    }
}
