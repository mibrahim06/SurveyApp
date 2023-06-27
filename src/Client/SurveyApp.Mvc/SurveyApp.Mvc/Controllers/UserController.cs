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
    
    [HttpGet("login/{provider}")]
    public  IActionResult LoginExternal([FromRoute] string provider,[FromQuery] string? returnUrl)
    {
        if (User != null && User.Identities.Any(identity => identity.IsAuthenticated))
        {
            RedirectToAction("Index", "Home");
        }
        returnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;
        var authenticationProperties = new AuthenticationProperties { RedirectUri = returnUrl };
        Console.WriteLine("LoginExternal");
        Console.WriteLine("PROVIDER: " + provider);
        return new ChallengeResult(provider, authenticationProperties);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Validate(UserLoginModel userInfo, string? returnUrl)
    {
        
        var isUserValid = _userService.Authenticate(userInfo.Username, userInfo.Password, out var claims);
        // If user is authenticated, redirect to returnUrl
        if (isUserValid)
        {
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var items = new Dictionary<string, string>();
            items.Add(".AuthScheme", CookieAuthenticationDefaults.AuthenticationScheme);
            var properties = new AuthenticationProperties(items);
            await HttpContext.SignInAsync(claimsPrincipal, properties);
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
    [HttpGet("denied")]
    public IActionResult Denied()
    {
        return View();
    }
}