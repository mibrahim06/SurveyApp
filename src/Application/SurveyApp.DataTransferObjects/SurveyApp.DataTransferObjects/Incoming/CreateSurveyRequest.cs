using System.ComponentModel.DataAnnotations;
using SurveyApp.Entities;

namespace SurveyApp.DataTransferObjects.Incoming;

public class CreateSurveyRequest
{
    [Required(ErrorMessage = "Anket adı boş olamaz!")]
    [StringLength(50, ErrorMessage = "Anket adı en fazla 50 karakter olabilir!")]
    [MinLength(3, ErrorMessage = "Anket adı en az 3 karakter olmalıdır!")]
    public string Name { get; set; }
    public int UserId { get; set; }
    public List<CreateQuestionRequest> Questions { get; set; }
}