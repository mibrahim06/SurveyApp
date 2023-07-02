using SurveyApp.DataTransferObjects.Incoming;

namespace SurveyApp.Mvc.Models;

public class CreateSurveyModel
{
    public CreateNewSurveyRequest CreateNewSurveyRequest { get; set; }
    public CreateNewQuestionRequest CreateNewQuestionRequest { get; set; }
}