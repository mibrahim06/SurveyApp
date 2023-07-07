using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public interface IQuestionRepository : IRepository<Question>
{
    public Task<ICollection<Option>> GetOptionsAsync(int questionId);
    public Task<ICollection<Answer>> GetAnswersAsync(int questionId);
}