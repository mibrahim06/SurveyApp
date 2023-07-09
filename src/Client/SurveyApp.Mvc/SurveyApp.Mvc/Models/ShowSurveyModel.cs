using SurveyApp.Entities;

namespace SurveyApp.Mvc.Models;

public class ShowSurveyModel
{
    public Survey Survey { get; set; }
    public List<Question> Questions { get; set; }
    public AnswerModel AnswerModel { get; set; }
}