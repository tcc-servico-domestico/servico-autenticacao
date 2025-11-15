using ServicoAutenticacao.Domain.Entities;
using ServicoAutenticacao.Domain.Interfaces.Repositories;
using ServicoAutenticacao.Infra.Data.Context;
using ServicoAutenticacao.Infra.Data.Repositories.Base;

namespace ServicoAutenticacao.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ServicoAutenticacaoDbContext contexto) : base(contexto) { }
    }
}
