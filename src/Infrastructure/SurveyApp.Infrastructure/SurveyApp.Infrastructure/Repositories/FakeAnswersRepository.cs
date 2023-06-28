using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public class FakeAnswersRepository : IAnswersRepository
{
    private readonly List<Answer> _answers;

    public FakeAnswersRepository()
    {
        var answer1 = new Answer()
        {
            Id = 1,
            QuestionId = 1,
            Rating = 5
        };
        var answer2 = new Answer()
        {
            Id = 2,
            QuestionId = 2,
            MultipleChoice = 3
        };
        
        var answer3 = new Answer()
        {
            Id = 3,
            QuestionId = 3,
            Text = "Answer 3"
        };
        
        _answers = new()
        {
            answer1,
            answer2,
            answer3,
        };
    }

    public Task<Answer?> GetByIdAsync(int id)
    {
        var answer = _answers.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(answer);
    }

    public Task<IEnumerable<Answer>> GetAllAsync()
    {
        var answers = _answers.AsEnumerable();
        return Task.FromResult(answers);
    }

    public Task AddAsync(Answer entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Answer entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Answer entity)
    {
        throw new NotImplementedException();
    }
}