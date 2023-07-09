using SurveyApp.DataTransferObjects.Incoming;
using SurveyApp.Entities;

namespace SurveyApp.Services;

public interface IQuestionService
{
    public Task<ICollection<Option>> GetOptionsAsync(int questionId);
    public Task<ICollection<Answer>> GetAnswersAsync(int questionId);
    
    public Task<int> CreateQuestion(CreateQuestionRequest request);
    public Task CreateOption(Option option);
    public Task CreateAnswer(Answer answer);
    public Task<int> GetOptionResponseCount(int optionId);
}