using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Incoming;
using SurveyApp.Entities;
using SurveyApp.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
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
        
        [HttpGet]
        public async  Task<IActionResult> GetSurveys()
        {
            var surveys = await _surveyService.GetSurveyDisplayResponses();
            return Ok(surveys);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurveyById(int id)
        {
            var survey = await _surveyService.GetSurveyById(id);
            return Ok(survey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            var surveyId = await _surveyService.CreateSurvey(request);
            var questions = request.Questions;
            foreach (var question in questions)
            {
                question.SurveyId = surveyId;
                var questionId = await _questionService.CreateQuestion(question);
                if (question.Options == null)
                {
                    continue;
                }
                foreach (var option in question.Options)
                {
                    var newOption = new Option()
                    {
                        QuestionId = questionId,
                        Text = option
                    };
                    await _questionService.CreateOption(newOption);
                }
                
            }
            return Ok(nameof(GetSurveyById));
        }
        

        [HttpGet("UserIds")]
        public async Task<IActionResult> AllUsers()
        {
            var users = await _userService.GetAllUserIds();
            return Ok(users);
        }
        
        [HttpGet("SurveyQuestions/{id}")]
        public async Task<IActionResult> GetSurveyQuestions(int id)
        {
            var questions = await _surveyService.GetQuestionsBySurveyId(id);
            return Ok(questions);
        }
        
        [HttpPost("Answer")]
        public async Task<IActionResult> AnswerQuestion(CreateAnswerRequest answer)
        {
            var response = new Answer()
            {
                QuestionId = answer.QuestionId,
                Text = answer.Text
            };
            await _questionService.CreateAnswer(response);
            return Ok();
        }
        

    }
}
