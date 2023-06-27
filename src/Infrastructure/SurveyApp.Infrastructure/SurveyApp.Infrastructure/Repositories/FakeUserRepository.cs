using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories;

//@Warning: This is a fake repository, it is used only for testing purposes.
public class FakeUserRepository : IUserRepository
{
    private readonly List<User> _users;

    public FakeUserRepository()
    {
        var user1 = new User
        {
            Id = 1,
            Name = "Mustafa Ibrahim",
            NameIdentifier = "Mustafa",
            UserName = "musibra",
            Password = "12345zxcv",
            Role = "Admin",
            Provider = "cookie",
            Email = "test@gmail.com",
            CreatedAt = DateTime.Now
        };

        var user2 = new User
        {
            Id = 2,
            Name = "Can",
            NameIdentifier = "kaya",
            UserName = "ckaya",
            Password = "123",
            Role = "User",
            Provider = "cookie",
            Email = "test2@gmail.com"
        };
        
        _users = new List<User> {user1, user2};
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        return await Task.FromResult(user);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await Task.FromResult(_users);
    }

    public Task AddAsync(User entity)
    {
        var user = _users.FirstOrDefault(u => u.Id == entity.Id);
        if (user == null)
        {
            _users.Add(entity);
        }

        return Task.CompletedTask;
    }

    public Task UpdateAsync(User entity)
    {
        var user = _users.FirstOrDefault(u => u.Id == entity.Id);
        if (user != null)
        {
            user = entity;
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(User? entity)
    {
        var user = _users.FirstOrDefault(u => entity != null && u.Id == entity.Id);
        if (user != null)
        {
            _users.Remove(user);
        }

        return Task.CompletedTask;
    }

    public async Task<User?> GetUserByUsernamePasswordAsync(string username, string password)
    {
        var user = _users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        return await Task.FromResult(user);
    }

    public Task<User?> GetUserByExternalProviderAsync(string provider, string nameIdentifier)
    {
        throw new NotImplementedException();
    }
}