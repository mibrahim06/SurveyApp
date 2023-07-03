using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SurveyApp.Entities;

public class Option : IEntity
{ 
    [Key]
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public string Text { get; set; }
}