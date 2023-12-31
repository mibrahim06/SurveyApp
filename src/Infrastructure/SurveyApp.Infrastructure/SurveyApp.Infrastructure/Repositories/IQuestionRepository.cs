using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public interface IQuestionRepository : IRepository<Question>
{
    public Task<ICollection<Option>> GetOptionsAsync(int questionId);
    public Task<ICollection<Answer>> GetAnswersAsync(int questionId);
    
    public Task<int> CreateQuestion(Question question);
    public Task CreateOption(Option option);
    public Task CreateAnswer(Answer answer);
    public Task<int> GetOptionResponseCount(int optionId, int QuestionId);
    public Task<int> GetResponseCount(int questionId, string text);
}