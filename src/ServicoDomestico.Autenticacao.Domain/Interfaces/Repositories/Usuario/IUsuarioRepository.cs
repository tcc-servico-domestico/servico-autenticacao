using ServicoDomestico.Autenticacao.Domain.Interfaces.Repositories.Base;
using ServicoDomestico.Autenticacao.Domain.Models.Usuario;

namespace ServicoDomestico.Autenticacao.Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseEscritaRepository<Usuario>, IBaseLeituraRepository<Usuario>
    {
        Task<Usuario> Logar(string userName, string senha);
        Task<Domain.Models.Usuario.Usuario> Cadastrar(Domain.Models.Usuario.Usuario usuario);
    }
}
