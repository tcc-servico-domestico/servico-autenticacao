namespace ServicoDomestico.Autenticacao.Domain.Models.Token
{
    public class Token
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public long ExpiraEm { get; set; }
        public bool Revogado { get; set; } = false;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public Usuario.Usuario Usuario { get; set; } = null!;
    }
}
