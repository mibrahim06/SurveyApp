using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SurveyApp.DataTransferObjects.Incoming;
using SurveyApp.DataTransferObjects.Outgoing;
using SurveyApp.Entities;
using SurveyApp.Mvc.Models;
using SurveyApp.Services;

namespace SurveyApp.Mvc.Controllers;

public class SurveyController : Controller
{
    private readonly ISurveyService _surveyService;
    private readonly IUserService _userService;
    public SurveyController(ISurveyService surveyService, IUserService userService)
    {
        _surveyService = surveyService;
        _userService = userService;
    }
    
    [Authorize]
    public IActionResult MySurveys()
    {
        var user = _userService.GetUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
        Console.WriteLine("=======================");
        Console.WriteLine( "Name Identifier: " + user.Name);
        Console.WriteLine( "User Id: " + user.Id);
        Console.WriteLine("=======================");
        var surveyDisplayResponses = _surveyService.GetSurveyDisplayResponsebByUserId(user.Id);
        return View(surveyDisplayResponses);
    }

    public IActionResult SurveyResults()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewData["SurveyId"] = id;
        var survey = _surveyService.GetUpdateSurveyRequestById(id);
        return View(survey);
    }
    
    public IActionResult AddQuestion(int id)
    {
        ViewBag.SurveyId = id;
        return View();
    }
    
    public IActionResult ShowSurvey(int id)
    {
        var survey = _surveyService.GetSurveyById(id);
        var questons = _surveyService.GetQuestionsBySurveyId(id);
        if (survey == null)
        {
            return Redirect("/Survey/NotFoundSurvey");
        }
        var model = new ShowSurveyModel
        {
            Survey = survey,
            Questions = questons
        };
        return View(model);
    }
    
    [Authorize]
    public IActionResult CreateSurvey()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateSurvey(CreateSurveyModel request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }
        
        return RedirectToAction("MySurveys");
    }
    
    
    [HttpGet]
    public IActionResult NotFoundSurvey()
    {
        return View();
    }
       
}