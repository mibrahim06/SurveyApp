using SurveyApp.Entities;

namespace SurveyApp.DataTransferObjects.Incoming;

public class CreateNewAnswerRequest
{ 
    public string? Text { get; set; }
    public QuestionType Type { get; set; }
    public int Rating { get; set; }
    public int MultipleChoice { get; set; }
    public int SingleChoice { get; set; }
}