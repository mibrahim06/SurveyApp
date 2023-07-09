using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public interface ISurveyRepository : IRepository<Survey>
{
    public Task<IEnumerable<Survey>> GetSurveysByUserId(int userId);
    public Task<Survey> GetSurveyById(int id);
    public Task<List<Question>> GetQuestionsBySurveyId(int surveyId);
    public Task<List<Survey>> GetSurveys();
    
    public Task<int> CreateSurvey(Survey survey);
}