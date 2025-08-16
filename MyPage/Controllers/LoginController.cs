using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MyPage.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {      
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Index(Admin admin)
        {
            Context c = new Context();
            var admininfo = c.Admins.FirstOrDefault
                (x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (admininfo != null)
            {            
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admininfo.UserName)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
                
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
