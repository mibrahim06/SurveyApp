using Microsoft.AspNetCore.Mvc;
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
    
}