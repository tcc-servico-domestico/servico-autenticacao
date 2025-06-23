using ServicoDomestico.Autenticacao.Application.ViewModel.Permissao;
using ServicoDomestico.Autenticacao.Application.ViewModel.Usuario;

namespace ServicoDomestico.Autenticacao.Application.ViewModel.Possui
{
    public class PossuiViewModel
    {
        public Guid UsuarioId { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public Guid PermissaoId { get; set; }
        public PermissaoViewModel Permissao { get; set; }
    }
}