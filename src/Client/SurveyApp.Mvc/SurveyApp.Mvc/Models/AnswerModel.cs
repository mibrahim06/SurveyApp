using SurveyApp.Entities;

namespace SurveyApp.Mvc.Models;

public class AnswerModel
{
    public ICollection<Option> Options { get; set; }
    public List<string> response { get; set; }

}