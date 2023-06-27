using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SurveyApp.Entities;

public class User : IEntity
{
    public int Id { get; set; }
    [AllowNull]
    public string Name { get; set; }
    public string NameIdentifier { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Provider { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    
}