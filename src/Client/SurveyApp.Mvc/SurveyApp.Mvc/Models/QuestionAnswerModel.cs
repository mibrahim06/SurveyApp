using SurveyApp.Entities;

namespace SurveyApp.Mvc.Models;

public class QuestionAnswerModel
{
    public Question question { get; set; }
    public ICollection<Answer> Answers { get; set; }
    public int answerCount { get; set; }
}