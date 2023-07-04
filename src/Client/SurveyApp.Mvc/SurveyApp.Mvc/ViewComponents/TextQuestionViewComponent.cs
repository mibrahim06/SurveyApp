using Microsoft.AspNetCore.Mvc;
using SurveyApp.Services;

namespace SurveyApp.Mvc.ViewComponents;

public class TextQuestionViewComponent : ViewComponent
{
    private readonly IQuestionService _questionService;
    public TextQuestionViewComponent(IQuestionService questionService)
    {
        _questionService = questionService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync(int questionId)
    {
        var options = await _questionService.GetOptionsAsync(questionId);
        return View(options);
    }
    
}