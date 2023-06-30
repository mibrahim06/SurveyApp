using System.Security.Claims;
using SurveyApp.Entities;

namespace SurveyApp.Services;

public interface IUserService
{
    bool Authenticate(string username, string password, out List<Claim> claims);
    User? GetUserByExternalProvider(string provider, string nameIdentifier);

    bool AddNewUser(string provider, List<Claim> claims);
    IEnumerable<User> GetAll();
    int GetUserId(string nameIdentifier);
    User GetUser(string nameIdentifier);
}