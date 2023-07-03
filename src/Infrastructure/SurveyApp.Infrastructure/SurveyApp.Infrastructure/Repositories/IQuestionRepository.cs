using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public interface IQuestionRepository : IRepository<Question>
{
    public Task<ICollection<Answer>> GetAnswersAsync(int questionId);
}