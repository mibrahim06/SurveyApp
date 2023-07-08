using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Data;

public class SurveyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Option> Options { get; set; }
    
    public DbSet<Answer> Answers { get; set; }
    

    public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
    {
        
    }
}