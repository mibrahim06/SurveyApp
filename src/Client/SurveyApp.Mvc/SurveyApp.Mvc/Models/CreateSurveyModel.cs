using SurveyApp.DataTransferObjects.Incoming;

namespace SurveyApp.Mvc.Models;

public class CreateSurveyModel
{
    public CreateSurveyRequest CreateSurveyRequest { get; set; }
    public CreateQuestionRequest CreateQuestionRequest { get; set; }
}