namespace ServicoDomestico.Autenticacao.Domain.Models.TrabalhadorDomestico
{
    public class TrabalhadorDomestico
    {
        public Guid Id { get; set; }
        public Guid PessoaId { get; set; }
        public decimal ValorHora { get; set; }
        public string Experiencia { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public Pessoa.Pessoa Pessoa { get; set; }
    }
}