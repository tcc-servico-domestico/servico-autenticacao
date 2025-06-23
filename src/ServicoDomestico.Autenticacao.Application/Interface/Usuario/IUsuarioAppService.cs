
using ServicoDomestico.Autenticacao.Application.ViewModel.Usuario;

namespace ServicoDomestico.Autenticacao.Application.Inteface.Usuario
{
    public interface IUsuarioAppService
    {
        Task<UsuarioViewModel> Logar(string userName, string senha);
        Task<UsuarioViewModel> Cadastrar(UsuarioViewModel usuario);
    }
}