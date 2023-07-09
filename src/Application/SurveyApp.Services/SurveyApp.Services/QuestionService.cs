using SurveyApp.DataTransferObjects.Incoming;
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


    public async Task<ICollection<Option>> GetOptionsAsync(int questionId)
    {
        var answers = await _questionRepository.GetOptionsAsync(questionId);
        return answers;
    }
    
    public async Task<ICollection<Answer>> GetAnswersAsync(int questionId)
    {
        var answers = await _questionRepository.GetAnswersAsync(questionId);
        return answers;
    }

    public async Task<int> CreateQuestion(CreateQuestionRequest request)
    {
        var optionType = GetOptionType(request.Type);
        var question = new Question
       {
           Title = request.Text,
           OptionType = optionType,
           SurveyId = request.SurveyId
       };
        var questionId = await _questionRepository.CreateQuestion(question); 
        return questionId;
    }

    public async Task CreateOption(Option option)
    {
        await _questionRepository.CreateOption(option);
    }

    public async Task CreateAnswer(Answer answer)
    {
        await _questionRepository.CreateAnswer(answer);
    }

    public async Task<int> GetOptionResponseCount(int optionId, int QuestionId)
    {
        var count = await _questionRepository.GetOptionResponseCount(optionId, QuestionId);
        return count;
    }

    public async Task<int> GetResponseCount(int questionId, string text)
    {
        var count = await _questionRepository.GetResponseCount(questionId, text);
        return count;
    }


    private OptionType GetOptionType(string optionType)
    {
        return optionType switch
        {
            "Text" => OptionType.Text,
            "Rating" => OptionType.Rating,
            "SingleChoice" => OptionType.SingleChoice,
            "MultipleChoice" => OptionType.MultipleChoice,
            _ => throw new ArgumentOutOfRangeException(nameof(optionType), optionType, null)
        };
    }
}