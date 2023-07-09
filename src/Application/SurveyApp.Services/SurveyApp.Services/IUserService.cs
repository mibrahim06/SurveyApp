using System.Security.Claims;
using SurveyApp.Entities;

namespace SurveyApp.Services;

public interface IUserService
{
    bool Authenticate(string username, string password, out List<Claim> claims);
    User? GetUserByExternalProvider(string provider, string nameIdentifier);

    bool AddNewUser(string provider, List<Claim> claims);
    Task<IEnumerable<User>> GetAll();
    public Task<int> GetUserId(string nameIdentifier);
    public Task<User> GetUser(string nameIdentifier);
}