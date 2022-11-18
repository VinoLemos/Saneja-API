using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Projeto_SaneJa.Models
{
    [Table("Imoveis")]
    public class Imovel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "RGI é obrigatório")]
        [StringLength(11, ErrorMessage = "Máximo de 11 dígitos")]
        public string Rgi { get; set; }
        [Required(ErrorMessage = "Nome da rua obrigatório")]
        [StringLength(80, ErrorMessage = "Deve ter no máximo 80 caracteres")]
        public string Rua { get; set; }
        public int Numero { get; set; }
        [StringLength(50)]
        public string? Complemento { get; set; }
        [Required]
        [StringLength(80)]
        public string Bairro { get; set; }
        [Required]
        public int Cep { get; set; }
        [Required]
        [StringLength(30)]
        public string Cidade { get; set; }
        [Required]
        [StringLength(30)]
        public string Estado { get; set; }
        [Required(ErrorMessage = "RGI é obrigatório")]
        [MaxLength(11, ErrorMessage = "Tamanho máximo de 11 caracteres!")]
        public string Hidrometro { get; set; }
        [Required]
        [StringLength(11)]
        public string? CpfProprietario { get; set; }
    }
}