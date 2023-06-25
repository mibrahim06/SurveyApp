using SurveyApp.Entities;

namespace SurveyApp.Services;

public interface IUserService
{
    User Authenticate(string username, string password);
}