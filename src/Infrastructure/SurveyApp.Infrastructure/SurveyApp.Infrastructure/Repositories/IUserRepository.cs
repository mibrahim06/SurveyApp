using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> GetUserByUsernamePasswordAsync(string username, string password);
    public Task<User?> GetUserByExternalProviderAsync(string provider, string nameIdentifier);
    int GetUserId(string nameIdentifier);
    User GetUser(string nameIdentifier);
}