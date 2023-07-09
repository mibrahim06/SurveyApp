using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> GetUserByUsernamePasswordAsync(string username, string password);
    public Task<User?> GetUserByExternalProviderAsync(string provider, string nameIdentifier);
    public Task<int> GetUserId(string nameIdentifier);
    public Task<User> GetUser(string nameIdentifier);
    public Task<List<int>> GetAllUserIds();
}