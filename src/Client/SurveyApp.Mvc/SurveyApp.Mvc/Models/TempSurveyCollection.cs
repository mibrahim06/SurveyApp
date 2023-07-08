using SurveyApp.Entities;

namespace SurveyApp.Mvc.Models;

public class TempSurveyCollection
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Question> Questions { get; set; } = new();
    public void ClearAll() => Questions.Clear();
    public int TotalQuestionsCount => Questions.Sum(i => i.Id);
}