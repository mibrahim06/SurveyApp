using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Data;

public class SurveyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    

    public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasMany(u => u.Surveys).WithOne(s => s.User);
        modelBuilder.Entity<Survey>().HasMany(s => s.Questions).WithOne(q => q.Survey);
    }
}