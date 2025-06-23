namespace ServicoDomestico.Autenticacao.Domain.Models.LogAcesso
{
    public class LogAcesso
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string Ip { get; set; } = string.Empty;
        public string? UserAgent { get; set; }
        public DateTime DataLogin { get; set; } = DateTime.UtcNow;
        public bool Sucesso { get; set; }
        public Usuario.Usuario Usuario { get; set; }
    }
}
