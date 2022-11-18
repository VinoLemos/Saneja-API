namespace Projeto_SaneJa.Dtos
{
    public class ImovelDTO
    {
        public int ID { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string? Complemento { get; set; }
        public int Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Rgi { get; set; }
        public string Hidrometro { get; set; }
        public string? CpfProprietario { get; set; }
    }
}
