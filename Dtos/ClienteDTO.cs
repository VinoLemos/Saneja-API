namespace Projeto_SaneJa.Dtos
{
    public class ClienteDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<ImovelDTO>? Imoveis { get; set; }
    }
}