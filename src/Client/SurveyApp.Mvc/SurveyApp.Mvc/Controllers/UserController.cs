using Microsoft.AspNetCore.Authentication;
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
    
    [HttpGet]
    public IActionResult Login(string? rtnUrl)
    {
        ViewBag.ReturnUrl = rtnUrl;
        return View();
    }

    [HttpPost]
    public IActionResult Login(UserLoginModel userInfo, string? rtnUrl)
    {
        if (ModelState.IsValid)
        {
            var user = _userService.Authenticate(userInfo.Username, userInfo.Password);
            if (user != null)
            {
                if(!string.IsNullOrEmpty(rtnUrl))
                {
                    return Redirect(rtnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("LoginError", "Kullanıcı adı veya şifre hatalı!");
        }
        return View();
    }
    
    public Task<IActionResult> Logout()
    {
        HttpContext.SignOutAsync();
        return Task.FromResult<IActionResult>(RedirectToAction("Index", "Home"));
    }
}