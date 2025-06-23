namespace ServicoDomestico.Autenticacao.Domain.Models.Pessoa
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

        // Navegações
        public ICollection<Telefone.Telefone> Telefones { get; set; }
        public TrabalhadorDomestico.TrabalhadorDomestico TrabalhadorDomestico { get; set; }
        public Usuario.Usuario Usuario { get; set; }
    }
}
