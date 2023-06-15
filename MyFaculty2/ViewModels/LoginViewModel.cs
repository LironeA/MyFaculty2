using System.ComponentModel.DataAnnotations;

namespace MyFaculty2.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Запам'ятати мене?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
