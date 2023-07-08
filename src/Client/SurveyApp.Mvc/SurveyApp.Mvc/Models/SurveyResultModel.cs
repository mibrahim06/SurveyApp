using SurveyApp.Entities;

namespace SurveyApp.Mvc.Models;

public class SurveyResultModel
{
    public string surveyTitle { get; set; }
    public List<QuestionAnswerModel> questionAnswers { get; set; }
}