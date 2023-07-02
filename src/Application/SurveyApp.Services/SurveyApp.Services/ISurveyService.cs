using SurveyApp.DataTransferObjects.Incoming;
using SurveyApp.DataTransferObjects.Outgoing;
using SurveyApp.Entities;

namespace SurveyApp.Services;

public interface  ISurveyService 
{
    public IEnumerable<SurveyDisplayResponse> GetSurveyDisplayResponses();
   
    public IEnumerable<SurveyDisplayResponse> GetSurveyDisplayResponsebByUserId(int userId);
    public UpdateSurveyRequest GetUpdateSurveyRequestById(int id);
    public IList<Survey> GetSurveysByUsername(string username);
}