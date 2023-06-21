using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Data;

public class SurveyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
    {
    }
    
}