namespace ServicoDomestico.Autenticacao.Domain.Models.Usuario
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public Guid PessoaId { get; set; }
        public Pessoa.Pessoa Pessoa { get; set; }

        public string Username { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }

        public ICollection<Permissao.Permissao> Permissoes { get; set; } = new List<Permissao.Permissao>();
    }
}
