using System.ComponentModel.DataAnnotations;

namespace EnglishDictionary.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан login")]
        public string Login { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
