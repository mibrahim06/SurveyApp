using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories;

public class EFQuestionRepository : IQuestionRepository
{
    private readonly SurveyDbContext _dbContext;
    public EFQuestionRepository(SurveyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Question?> GetByIdAsync(int id)
    {
        var question = await _dbContext.Questions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return question;
    }

    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        var questions = await _dbContext.Questions.AsNoTracking().ToListAsync();
        return questions;
    }

    public async Task AddAsync(Question entity)
    {
        var addingQuestion = await _dbContext.Questions.AddAsync(entity);
    }

    public Task UpdateAsync(Question entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Question entity)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Option>> GetOptionsAsync(int questionId)
    {
        var options = await _dbContext.Options.Where(x => x.QuestionId == questionId).ToListAsync();
        return options;
    }

    public async Task<ICollection<Answer>> GetAnswersAsync(int questionId)
    {
        var answers = await _dbContext.Answers.Where(x => x.QuestionId == questionId).ToListAsync();
        return answers;
    }
}