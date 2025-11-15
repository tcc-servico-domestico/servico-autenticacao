using ServicoAutenticacao.Domain.Entities;
using ServicoAutenticacao.Domain.Interfaces.Services;
using ServicoAutenticacao.Domain.Interfaces.Repositories;
using ServicoAutenticacao.Domain.Services.Base;

namespace ServicoAutenticacao.Domain.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository) : base(repository) { }
    }
}
