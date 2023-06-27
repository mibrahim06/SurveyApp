using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Data;

public static class DatabaseSeeding
{
    public static void Seed(SurveyDbContext dbContext)
    {
        SeedUsers(dbContext);
    }

    private static void SeedUsers(SurveyDbContext dbContext)
    {
        if (!dbContext.Users.Any())
        {
            var user1 = new User
            {
                Name = "Mustafa Ibrahim",
                NameIdentifier = "Mustafa",
                UserName = "musibra",
                Password = "12345zxcv",
                Role = "Admin",
                Provider = "Cookies",
                Email = "test@gmail.com",
                CreatedAt = DateTime.Now
            };

            var user2 = new User
            {
                Name = "Can",
                NameIdentifier = "kaya",
                UserName = "ckaya",
                Password = "123",
                Role = "User",
                Provider = "Cookies",
                Email = "test2@gmail.com",
                CreatedAt = DateTime.Now
            };
        
            var _users = new List<User> {user1, user2};
            dbContext.Users.AddRange(_users);
            dbContext.SaveChanges();
        }
    }
}