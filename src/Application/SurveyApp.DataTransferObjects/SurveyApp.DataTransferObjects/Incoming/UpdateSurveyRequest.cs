using System.ComponentModel.DataAnnotations;
using SurveyApp.Entities;

namespace SurveyApp.DataTransferObjects.Incoming;

public class UpdateSurveyRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Anket adı boş olamaz!")]
    [StringLength(50, ErrorMessage = "Anket adı en fazla 50 karakter olabilir!")]
    [MinLength(3, ErrorMessage = "Anket adı en az 3 karakter olmalıdır!")]
    public string Name { get; set; }
    public int UserId { get; set; }
    [Required(ErrorMessage = "Anket soruları boş olamaz!")]
    public ICollection<Question> Questions { get; set; }
}