using MyFaculty2.Models;
using System.ComponentModel.DataAnnotations;

namespace MyFaculty2.ViewModels
{
    public class RegisterTeacherViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Дата народження")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "ПІБ")]
        public int TeacherId { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [Display(Name = "Підтвердження Пароля")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}