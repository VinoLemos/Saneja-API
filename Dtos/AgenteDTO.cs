namespace Projeto_SaneJa.Dtos
{
    public class AgenteDTO
    {
        public int ID { get; set; }
        public int Matricula { get; set; }
        public string? Nome { get; set; }
        public string? Rg { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
    }
}