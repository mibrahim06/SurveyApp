using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public class FakeQuestionRepository : IQuestionRepository
{
    private readonly List<Question> _questions;

    public FakeQuestionRepository()
    {
        var question1 = new Question()
        {
            Id = 1,
            Title = "Question 1",
            SurveyId = 1
        };
        var question2 = new Question()
        {
            Id = 2,
            Title = "Question 2",
            SurveyId = 1
        };
        var question3 = new Question()
        {
            Id = 3,
            Title = "Question 3",
            SurveyId = 1
        };
        _questions = new()
        {
            question1,
            question2,
            question3,
        };
    }
    public Task<Question?> GetByIdAsync(int id)
    {
        var question = _questions.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(question);
    }

    public Task<IEnumerable<Question>> GetAllAsync()
    {
        var questions = _questions.AsEnumerable();
        return Task.FromResult(questions);
    }

    public Task AddAsync(Question entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Question entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Question entity)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Option>> GetOptionsAsync(int questionId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Answer>> GetAnswersAsync(int questionId)
    {
        throw new NotImplementedException();
    }
}