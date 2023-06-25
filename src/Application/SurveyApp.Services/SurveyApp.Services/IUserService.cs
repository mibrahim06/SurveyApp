using SurveyApp.Entities;

namespace SurveyApp.Services;

public interface IUserService
{
    User GetById(int id);
    IEnumerable<User> GetAll();
    public User? Authenticate(string username, string password);
}