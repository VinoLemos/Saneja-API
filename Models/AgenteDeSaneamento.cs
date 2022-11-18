using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_SaneJa.Models
{
    [Table("Agentes")]
    public class AgenteDeSaneamento : IUsuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int Matricula { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(80, ErrorMessage = "O nome deve ter entre 5 e 80 caracteres", MinimumLength = 5)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "RG é obrigatório!")]
        [StringLength(9)]
        public string Rg { get; set; }
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Telefone é obrigatório")]
        [MaxLength(11)]
        public string Telefone { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}