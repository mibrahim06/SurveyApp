using SurveyApp.DataTransferObjects.Incoming;
using SurveyApp.DataTransferObjects.Outgoing;
using SurveyApp.Entities;

namespace SurveyApp.Services;

public interface  ISurveyService 
{
    public Task<IEnumerable<SurveyDisplayResponse>> GetSurveyDisplayResponses();
   
    public Task<IEnumerable<SurveyDisplayResponse>> GetSurveyDisplayResponseByUserId(int userId);
    public Task<UpdateSurveyRequest> GetUpdateSurveyRequestById(int id);
    public Task<IList<Survey>> GetSurveysByUsername(string username);
    public Task<List<Question>> GetQuestionsBySurveyId(int surveyId);
    public Task<Survey> GetSurveyById(int id);
}