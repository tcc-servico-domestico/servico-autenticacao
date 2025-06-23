namespace ServicoDomestico.Autenticacao.Domain.Models.Permissao
{
    public class Permissao
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }

        public ICollection<Possui.Possui> Usuarios { get; set; }
    }
}
