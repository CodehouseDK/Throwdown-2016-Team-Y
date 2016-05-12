﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Mvc;

namespace TeamY.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public async Task<IActionResult> Unauthorized(string returnUrl = null)
        {
            const string Issuer = "https://contoso.com";

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "hgh", ClaimValueTypes.String, Issuer),
                new Claim(ClaimTypes.Role, "Administrator", ClaimValueTypes.String, Issuer),
                //new Claim("EmployeeId", "123", ClaimValueTypes.String, Issuer),
                //new Claim(ClaimTypes.DateOfBirth, "1970-06-08", ClaimValueTypes.Date),
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

            return RedirectToLocal(returnUrl);
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}