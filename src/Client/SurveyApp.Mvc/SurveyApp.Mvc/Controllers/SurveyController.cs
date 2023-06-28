using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SurveyApp.Services;

namespace SurveyApp.Mvc.Controllers;

public class SurveyController : Controller
{
    private readonly ISurveyService _surveyService;
    public SurveyController(ISurveyService surveyService)
    {
        _surveyService = surveyService;
    }
    
    [Authorize]
    public IActionResult MySurveys()
    {
        var surveys = _surveyService.GetSurveyDisplayResponses();
        return View(surveys);
    }
    [Authorize]
    public IActionResult CreateSurvey()
    {
        return View();
    }
}