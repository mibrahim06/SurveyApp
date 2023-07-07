using SurveyApp.Entities;

namespace SurveyApp.Mvc.Models;

public class SurveyResultsModel
{
   public Survey Survey { get; set; } 
   public List<Question> Questions { get; set; }
   public ICollection<Answer> Answers { get; set; }
    // TODO : implement this
}