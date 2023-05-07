using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class SignUpDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "E-mail is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required, Compare("Password", ErrorMessage = "The passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}
