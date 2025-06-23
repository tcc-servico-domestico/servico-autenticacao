namespace ServicoDomestico.Autenticacao.Domain.Models.Possui
{
    public class Possui
    {
        public Guid UsuarioId { get; set; }
        public Usuario.Usuario Usuario { get; set; }

        public Guid PermissaoId { get; set; }
        public Permissao.Permissao Permissao { get; set; }
    }

}