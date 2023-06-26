using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories;

public class EFUserRepository : IUserRepository
{
    private readonly SurveyDbContext _dbContext;
    public EFUserRepository(SurveyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _dbContext.Users.AsNoTracking().ToListAsync();
        return users;
    }

    public async Task AddAsync(User entity)
    {
        var addingUser = await _dbContext.Users.AddAsync(entity); 
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        var updatingUser =  _dbContext.Users.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(User entity)
    {
        var deletingUser = _dbContext.Users.Remove(entity);
        return _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserByUsernamePasswordAsync(string username, string password)
    {
        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
        return user;
    }
}