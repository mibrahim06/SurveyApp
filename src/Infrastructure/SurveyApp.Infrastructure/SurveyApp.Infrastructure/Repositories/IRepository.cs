using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public interface IRepository<T> where T : class, IEntity, new()
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}