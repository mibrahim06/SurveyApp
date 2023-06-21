using SurveyApp.Entities;

namespace SurveyApp.Services;

public interface IUserService
{
    Task<User> Authenticate(string username, string password);
    Task<User> AuthenticateExternal(string provider, string nameIdentifier);
    Task<User> Create(User user);
    Task<User> Update(User user);
    Task<User> GetById(int id);
    Task<User> GetByName(string name);
    Task<User> GetByNameIdentifier(string nameIdentifier);
    Task<User> GetByEmail(string email);
    Task<IEnumerable<User>> GetAll();
    Task Delete(int id);
}