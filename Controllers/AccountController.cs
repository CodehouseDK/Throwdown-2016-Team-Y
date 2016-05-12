using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Mvc;
using TeamY.Infrastructure;

namespace TeamY.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly TeamyDbContext _context;

        public AccountController(TeamyDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName)
        {
            var user = _context.Users.SingleOrDefault(x => x.Initials == userName);
            if (user == null)
            {
                throw new Exception("user not found");
            }

            const string issuer = "https://codehouse.com";

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Initials, ClaimValueTypes.String, issuer),
                new Claim(ClaimTypes.Role, "Administrator", ClaimValueTypes.String, issuer),
            };
            var userIdentity = new ClaimsIdentity("SuperSecureLogin");
            userIdentity.AddClaims(claims);

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookie");

            return RedirectToAction("Index", "Home");
        }
    }
}