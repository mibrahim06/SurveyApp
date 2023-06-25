using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByUsernamePasswordAsync(string username, string password);
}