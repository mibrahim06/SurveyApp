using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public User GetById(int id)
    {
        var user = _userRepository.GetByIdAsync(id).Result;
        if (user == null)
        {
            return null;
        }
        return user;
    }

    public IEnumerable<User> GetAll()
    {
        var users = _userRepository.GetAllAsync().Result;
        if (users == null)
        {
            return null;
        }
        return users;
    }
    
    public User? Authenticate(string username, string password)
    {
        var user = _userRepository.GetUserByUsernamePasswordAsync(username, password).Result;
        if (user == null)
        {
            return null;
        }
        return user;
    }
}