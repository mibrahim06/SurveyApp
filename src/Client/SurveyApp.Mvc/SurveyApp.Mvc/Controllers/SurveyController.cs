using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SurveyApp.Mvc.Controllers;

public class SurveyController : Controller
{
    [Authorize]
    public IActionResult MySurveys()
    {
        return View();
    }
    [Authorize]
    public IActionResult CreateSurvey()
    {
        return View();
    }
}