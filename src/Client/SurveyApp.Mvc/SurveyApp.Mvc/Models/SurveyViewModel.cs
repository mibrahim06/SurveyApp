using SurveyApp.DataTransferObjects.Outgoing;

namespace SurveyApp.Mvc.Models;

public class SurveyViewModel
{
    public IEnumerable<SurveyDisplayResponse> Surveys { get; set; }
    public IEnumerable<QuestionDisplayResponse> Questions { get; set; }
}