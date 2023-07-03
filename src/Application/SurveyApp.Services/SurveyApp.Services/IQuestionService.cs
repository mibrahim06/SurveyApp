using SurveyApp.Entities;

namespace SurveyApp.Services;

public interface IQuestionService
{
    public Task<ICollection<Option>> GetAnswersAsync(int questionId);
}