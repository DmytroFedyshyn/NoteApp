using System.ComponentModel.DataAnnotations;

namespace NoteApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указан Email адрес")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
