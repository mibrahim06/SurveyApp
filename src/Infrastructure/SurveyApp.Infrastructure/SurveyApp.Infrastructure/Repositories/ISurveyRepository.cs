using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public interface ISurveyRepository : IRepository<Survey>
{
    public Task<IEnumerable<Survey>> GetSurveysByUserId(int userId);
}