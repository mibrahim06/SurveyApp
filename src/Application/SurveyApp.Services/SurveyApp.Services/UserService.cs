using System.Security.Claims;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;
using SurveyApp.Services.ServicesExtensions;

namespace SurveyApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool Authenticate(string username, string password, out List<Claim> claims)
    {
        claims = new List<Claim>();
        var user = _userRepository.GetUserByUsernamePasswordAsync(username, password).Result;
        if (user == null)
        {
            return false;
        }
        else
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
            claims.Add(new Claim("username", username));
            claims.Add(new Claim(ClaimTypes.GivenName, user.Name));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Role, user.Role));
            claims.Add(new Claim("Provider", user.Provider));
        }

        return true;
    }
    
    public User? GetUserByExternalProvider(string provider, string nameIdentifier)
    {
        return _userRepository.GetUserByExternalProviderAsync(provider, nameIdentifier).Result;
    }

    public bool AddNewUser(string provider, List<Claim> claims)
    {
        var user = new User
        {
            // TODO : Email and password are incorrect here, this is just a demo
            NameIdentifier = claims.GetClaim(ClaimTypes.NameIdentifier),
            UserName = claims.GetClaim(ClaimTypes.GivenName),
            Name = claims.GetClaim(ClaimTypes.GivenName),
            Password = claims.GetClaim(ClaimTypes.NameIdentifier),
            Role = "User",
            Provider = provider,
            Email = claims.GetClaim(ClaimTypes.NameIdentifier),
            CreatedAt = DateTime.Now
        };
        _userRepository.AddAsync(user).Wait();
        return true;
    }

    public IEnumerable<User> GetAll()
    {
        return _userRepository.GetAllAsync().Result;
    }
}