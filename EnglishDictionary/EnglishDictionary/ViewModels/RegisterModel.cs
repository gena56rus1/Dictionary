using System.ComponentModel.DataAnnotations;

namespace EnglishDictionary.ViewModels
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Не указан login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
