using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Mvc.Models;

public class UserLoginModel
{
    [Required(ErrorMessage = "Kullanıcı adı boş olamaz!")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Şifre boş olamaz!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}