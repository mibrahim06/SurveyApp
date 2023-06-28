namespace SurveyApp.Entities;

public class Survey : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public ICollection<Question> Questions { get; set; }
}