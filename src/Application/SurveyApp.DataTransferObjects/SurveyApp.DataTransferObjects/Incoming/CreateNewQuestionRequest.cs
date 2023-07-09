using System.ComponentModel.DataAnnotations;
using SurveyApp.Entities;

namespace SurveyApp.DataTransferObjects.Incoming;

public class CreateNewQuestionRequest
{
    [Required(ErrorMessage = "Soru boş olamaz!")]
    public string? Text { get; set; }
    [Required(ErrorMessage = "Soru tipi boş olamaz!")]
    public string Type { get; set; }
    public List<Option> Options { get; set; }
}