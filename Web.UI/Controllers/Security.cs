using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.UI.Data;
using Web.UI.Models.Request;

namespace Web.UI.Controllers
{
    [Authorize]
    public class Security : Controller
    {
        private readonly ApplicationDbContext _context;

        public Security(ApplicationDbContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate(ReqUserLogin reqGetUserLogin)
        {

            if (reqGetUserLogin.Password == null)
            {
                reqGetUserLogin.Password = "";
            }
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(m => m.UserName == reqGetUserLogin.UserName && m.Passwword == reqGetUserLogin.Password);
                if (user == null)
                {
                    TempData["Error"] = "Kullanıcı Adı Yada Şifre Yanlış";
                    return View();
                }
                var claims = new List<Claim>
                    {
                          new Claim(ClaimTypes.Name, user.UserName),
                          new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {

                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                    IsPersistent = true,

                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Authenticate()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Error404()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {


            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Authenticate");

        }
    }
}