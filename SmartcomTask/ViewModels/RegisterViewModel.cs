using System.ComponentModel.DataAnnotations;

namespace SmartcomTask.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [MinLength(8, ErrorMessage = "{0} должен содержать не менее {1} символов")]
        public string Password { get; set; }

        public string Address { get; set; }
    }
}
