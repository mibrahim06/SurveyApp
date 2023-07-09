using System.ComponentModel.DataAnnotations;
using SurveyApp.Entities;

namespace SurveyApp.DataTransferObjects.Incoming;

public class CreateQuestionRequest
{
    [Required(ErrorMessage = "Soru boş olamaz!")]
    public string? Text { get; set; }
    [Required(ErrorMessage = "Soru tipi boş olamaz!")]
    public string Type { get; set; }
    public List<String> Options { get; set; }
    public int SurveyId { get; set; }
}