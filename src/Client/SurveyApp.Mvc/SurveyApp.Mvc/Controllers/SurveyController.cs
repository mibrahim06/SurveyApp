using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public async Task<IActionResult> MySurveys()
    {
        var user =  await _userService.GetUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var surveyDisplayResponses = await _surveyService.GetSurveyDisplayResponseByUserId(user.Id);
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
            var answers = await _questionService.GetAnswersAsync(question.Id);
            var questionAnswer = new QuestionAnswerModel
            {
                question = question,
                Answers = answers,
                answerCount = answers.Count
            };
            surveyResults.questionAnswers.Add(questionAnswer);
        }
        return View(surveyResults);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        ViewData["SurveyId"] = id;
        var updateSurveyRequest = await _surveyService.GetUpdateSurveyRequestById(id);
        return View(updateSurveyRequest);
    }
    
    public IActionResult AddQuestion(int id)
    {
        ViewBag.SurveyId = id;
        // TODO: Find a better way to do this
        var QuestionTypeSelectList = new List<SelectListItem>
        {
            new SelectListItem("Çoktan Seçmeli", "MultipleChoice"),
            new SelectListItem("Tek seçim", "SingleChoice"),
            new SelectListItem("Yorum", "Text"),
            new SelectListItem("Puan", "Rating")
        };
        ViewBag.QuestionTypeSelectList = QuestionTypeSelectList;
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

    [HttpPost("Survey/AddSurveyAnswer")]
    public async Task<IActionResult> AddSurveyAnswer(ShowSurveyModel model)
    {
        return View();
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