using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Entities;

public class User : IEntity
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string NameIdentifier { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Role { get; set; }
    [Required]
    public string Provider { get; set; }
    [Required]
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    
}