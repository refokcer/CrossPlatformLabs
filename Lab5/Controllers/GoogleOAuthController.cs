using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Lab5.Data;
using Lab5.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

public class GoogleOAuthController(ApplicationDbContext applicationDbContext) : Controller
{
    public IActionResult RedirectOnOAuthServer()
    {
        var redirectUrl = "http://localhost:5018/GoogleOAuth/Code";
        var codeVerifier = Guid.NewGuid().ToString();

        HttpContext.Session.SetString("codeVerifier", codeVerifier);

        using var sha256 = SHA256.Create();
        var challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));
        var codeChallenge = Base64UrlTextEncoder.Encode(challengeBytes);

        var url = GoogleOAuthService.GenerateOAuthRequestUrl(redirectUrl, "https://www.googleapis.com/auth/userinfo.profile", codeChallenge);
        return Redirect(url);
    }

    public async Task<IActionResult> Code(string code)
    {
        var codeVerifier = HttpContext.Session.GetString("codeVerifier");
        var redirectUrl = "http://localhost:5018/GoogleOAuth/Code";
        var tokenResult = await GoogleOAuthService.GetTokenByCode(code, codeVerifier, redirectUrl);

        HttpContext.Session.SetString("token", tokenResult.AccessToken);
        var googleId = await GoogleOAuthService.GetGoogleId(tokenResult.AccessToken);
        var foundUser = applicationDbContext.Users.FirstOrDefault(user => user.GoogleId == googleId);
        if (foundUser == null)
        {
            return RedirectToAction($"Register", "Account");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, foundUser.Username),
            new Claim(ClaimTypes.Email, foundUser.Email),
            new Claim("FullName", foundUser.FullName),
            new Claim(ClaimTypes.MobilePhone, foundUser.PhoneNumber),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        return RedirectToAction("Index", "Home");
    }
}