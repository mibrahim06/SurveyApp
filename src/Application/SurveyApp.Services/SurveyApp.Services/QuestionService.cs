using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    
    public QuestionService(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }


    public async Task<ICollection<Option>> GetAnswersAsync(int questionId)
    {
        var answers = await _questionRepository.GetOptionsAsync(questionId);
        return answers;
    }
}