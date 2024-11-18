using System.Security.Claims;
using Lab5.Data;
using Lab5.Data.Entities;
using Lab5.Models;
using Lab5.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

public class AccountController(ApplicationDbContext applicationDbContext) : Controller
{
    public IActionResult Register(string id)
    {
        return View(new RegisterModel());
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        var token = HttpContext.Session.GetString("token");
        if (ModelState.IsValid && token != null)
        {
            if (applicationDbContext.Users.FirstOrDefault(u => u.Username == model.Username) != null)
            {
                return View(model);
            }
            var googleId = await GoogleOAuthService.GetGoogleId(token);
            var user = Data.Entities.User.Create(model, googleId);

            applicationDbContext.Users.Add(user);
            await applicationDbContext.SaveChangesAsync();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FullName", user.FullName),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }


    public IActionResult Logout()
    {
        HttpContext.SignOutAsync();
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    public IActionResult Profile()
    {
        var claims = new List<Claim>(User.Claims);

        return View(new ProfileModel()
        {
            Username = claims[0].Value,
            Email = claims[1].Value,
            FullName = claims[2].Value,
            Phone = claims[3].Value
        });
    }
}