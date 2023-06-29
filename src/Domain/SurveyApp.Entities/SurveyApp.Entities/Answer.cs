using System.Diagnostics.CodeAnalysis;

namespace SurveyApp.Entities;

public class Answer
{ 
    public int Id { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }
    public int MultipleChoice { get; set; }
    public int SingleChoice { get; set; }
}