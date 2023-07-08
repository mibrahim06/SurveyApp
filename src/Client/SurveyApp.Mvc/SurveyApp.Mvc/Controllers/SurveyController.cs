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
    private readonly IQuestionService _questionService;
  
    public SurveyController(ISurveyService surveyService, IUserService userService, IQuestionService questionService)
    {
        _surveyService = surveyService;
        _userService = userService;
        _questionService = questionService;
    }
    
    [Authorize]
    public IActionResult MySurveys()
    {
        var user = _userService.GetUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var surveyDisplayResponses = _surveyService.GetSurveyDisplayResponsebByUserId(user.Id);
        return View(surveyDisplayResponses);
    }

    [Authorize]
    public  async Task<IActionResult> SurveyResults(int id)
    {
        var survey = await _surveyService.GetSurveyById(id);
        var questions = await _surveyService.GetQuestionsBySurveyId(id);
        var surveyResults = new SurveyResultModel
        {
            surveyTitle = survey.Name,
            questionAnswers = new List<QuestionAnswerModel>()
        };
        
        foreach (var question in questions)
        {
            var questionAnswer = new QuestionAnswerModel
            {
                question = question,
                Answers = await _questionService.GetAnswersAsync(question.Id),
            };
            surveyResults.questionAnswers.Add(questionAnswer);
        }
        return View(surveyResults);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewData["SurveyId"] = id;
        var updateSurveyRequest = _surveyService.GetUpdateSurveyRequestById(id);
        return View(updateSurveyRequest);
    }
    
    public IActionResult AddQuestion(int id)
    {
        ViewBag.SurveyId = id;
        return View();
    }
    
    public async Task<IActionResult> ShowSurvey(int id)
    {
        var survey = await _surveyService.GetSurveyById(id);
        var questions = await _surveyService.GetQuestionsBySurveyId(id);
        foreach (var question in questions)
        {
            question.Options = await _questionService.GetOptionsAsync(question.Id);
        }
        if (survey == null)
        {
            return Redirect("/Survey/NotFoundSurvey");
        }
        
        var model = new ShowSurveyModel
        {
            Survey = survey,
            Questions = questions
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
        // TODO: Make this view look better
        return View();
    }
}