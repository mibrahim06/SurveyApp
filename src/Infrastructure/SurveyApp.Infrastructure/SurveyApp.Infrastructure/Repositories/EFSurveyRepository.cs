using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories;

public class EFSurveyRepository : ISurveyRepository
{
    private readonly SurveyDbContext _dbContext;
    public EFSurveyRepository(SurveyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Survey?> GetByIdAsync(int id)
    {
        var survey = await _dbContext.Surveys.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return survey;
    }

    public async Task<IEnumerable<Survey>> GetAllAsync()
    {
        var surveys = await _dbContext.Surveys.AsNoTracking().ToListAsync();
        return surveys;
    }

    public async Task AddAsync(Survey entity)
    {
        var addingSurvey = await _dbContext.Surveys.AddAsync(entity); 
        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateAsync(Survey entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Survey entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Survey>> GetSurveysByUserId(int userId)
    {
        var surveys = await _dbContext.Surveys.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
        return surveys;
    }

    public async Task<Survey> GetSurveyById(int id)
    {
        var survey = await _dbContext.Surveys.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return survey;
    }

    public async  Task<List<Question>> GetQuestionsBySurveyId(int surveyId)
    {
        var questions = await _dbContext.Questions.AsNoTracking().Where(x => x.SurveyId == surveyId).ToListAsync();
        return questions;
    }

    public async Task<List<Survey>> GetSurveys()
    {
        var surveys = await _dbContext.Surveys.AsNoTracking().ToListAsync();
        return surveys;
    }

    public async Task<int> CreateSurvey(Survey survey)
    {
        var addingSurvey = await _dbContext.Surveys.AddAsync(survey);
        await _dbContext.SaveChangesAsync();
        return addingSurvey.Entity.Id;
    }
}