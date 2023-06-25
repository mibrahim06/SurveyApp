using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Mvc.Models;
using SurveyApp.Services;

namespace SurveyApp.Mvc.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet("login")]
    public IActionResult Login(string? returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Validate(UserLoginModel userInfo, string? returnUrl)
    {
        
        var user = _userService.Authenticate(userInfo.Username, userInfo.Password);
        // If user is authenticated, redirect to returnUrl
        if (user != null)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("username", user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
            claims.Add(new Claim("password", user.Password));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);
            return Redirect(returnUrl ?? "/");
        }
        // If user is not authenticated, return to login page with error message
        TempData["error"] = "Kullanıcı adı veya şifre hatalı!";
        return View("login");
    }
    
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect("/");
    }
}