using SurveyApp.Entities;

namespace SurveyApp.Services;

public interface IQuestionService
{
    public Task<ICollection<Answer>> GetAnswersAsync(int questionId);
}