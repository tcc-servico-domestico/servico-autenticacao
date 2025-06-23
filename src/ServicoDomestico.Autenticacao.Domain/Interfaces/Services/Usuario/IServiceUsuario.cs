using ServicoDomestico.Autenticacao.Domain.Interfaces.Services.Base;

namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Models.Usuario.Usuario>
    {
        Task<Models.Usuario.Usuario> Logar(string userName, string senha);
        Task<Models.Usuario.Usuario> Cadastrar(Models.Usuario.Usuario usuario, bool aplicarAlteracoes = false);
    }
}