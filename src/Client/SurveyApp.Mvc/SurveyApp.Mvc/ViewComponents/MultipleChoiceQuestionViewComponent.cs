using Microsoft.AspNetCore.Mvc;
using SurveyApp.Mvc.Models;
using SurveyApp.Services;

namespace SurveyApp.Mvc.ViewComponents;

public class MultipleChoiceQuestionViewComponent : ViewComponent
{
    private readonly IQuestionService _questionService;
    public MultipleChoiceQuestionViewComponent(IQuestionService questionService)
    {
        _questionService = questionService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync(int questionId)
    {
        var options = await _questionService.GetOptionsAsync(questionId);
        var model = new AnswerModel()
        {
            Options = options
        };
        return View(model);
    }
}