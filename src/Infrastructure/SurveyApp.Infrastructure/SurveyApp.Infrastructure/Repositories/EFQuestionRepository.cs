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
        // TODO: Implement this method
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Question entity)
    {
        // TODO: Implement this method
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

    public async Task<int> CreateQuestion(Question question)
    {
        var addingQuestion = await _dbContext.Questions.AddAsync(question);
        await _dbContext.SaveChangesAsync();
        return addingQuestion.Entity.Id;
    }

    public async Task CreateOption(Option option)
    {
        var addingOption = await _dbContext.Options.AddAsync(option);
        await _dbContext.SaveChangesAsync();
    }

    public async Task CreateAnswer(Answer answer)
    {
        var addingAnswer = await _dbContext.Answers.AddAsync(answer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> GetOptionResponseCount(int optionId, int QuestionId)
    {
        var optionText = await _dbContext.Options.Where(x => x.Id == optionId).Select(x => x.Text).FirstOrDefaultAsync();
        var count = await _dbContext.Answers.Where(x => x.Text == optionText && x.QuestionId == QuestionId).CountAsync();
        return count;
    }

    public async Task<int> GetResponseCount(int questionId, string text)
    {
        var count = await _dbContext.Answers.Where(x => x.Text == text && x.QuestionId == questionId).CountAsync();
        return count;
    }

    
}