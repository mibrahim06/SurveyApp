using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public class FakeSurveyRepository : IRepository<Survey>
{
    private readonly List<Survey> _surveys;

    public FakeSurveyRepository()
    {
        var survey1 = new Survey()
        {
            Id = 1,
            Name = "Survey 1",
            UserId = 1,
        };
        var survey2 = new Survey()
        {
            Id = 2,
            Name = "Survey 2",
            UserId = 1,
        };
        
        _surveys = new()
        {
            survey1,
            survey2,
        };
    }
    
    public Task<Survey?> GetByIdAsync(int id)
    {
        var survey = _surveys.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(survey);
    }

    public Task<IEnumerable<Survey>> GetAllAsync()
    {
        var surveys = _surveys.AsEnumerable();
        return Task.FromResult(surveys);
    }

    public Task AddAsync(Survey entity)
    {
       var survey = _surveys.FirstOrDefault(x => x.Id == entity.Id);
         if (survey == null)
         {
              _surveys.Add(entity);
         }
         return Task.FromResult(entity);
    }

    public Task UpdateAsync(Survey entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Survey entity)
    {
        throw new NotImplementedException();
    }
}