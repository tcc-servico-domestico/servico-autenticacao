namespace ServicoDomestico.Autenticacao.Domain.Models.Telefone
{
    public class Telefone
    {
        public Guid TelefoneId { get; set; }
        public Guid PessoaId { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public Pessoa.Pessoa Pessoa { get; set; }
    }
}