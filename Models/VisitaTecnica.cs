using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Projeto_SaneJa.Models
{
    [Table("Visitas")]
    public class VisitaTecnica
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "RGI é obrigatório")]
        [StringLength(11, ErrorMessage = "Máximo de 11 dígitos")]
        public string rgiImovel { get; set; }        
        public int? matriculaAgente { get; set; }
        [Required]
        [StringLength(11)]
        public string cpfProprietario { get; set; }
        [Required]
        public DateTime DataSolicitacao { get; set; }
        [Required]
        public DateTime DataVisita { get; set; }
        public DateTime DataRetorno { get; set; }
        public DateTime DataHomologacao { get; set; }
        public bool Homologacao { get; set; }
        public string? Observacao { get; set; }
        public enum StatusVisita { Ativa, Pendente, EmAndamento, Concluida }
        [Required]
        public StatusVisita Status { get; set; }
    }
}