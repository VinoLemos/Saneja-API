using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.User
{
    public class UserDto
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1] caracteres.")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}
