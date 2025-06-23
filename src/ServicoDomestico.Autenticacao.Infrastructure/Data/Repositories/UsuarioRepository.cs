using Microsoft.EntityFrameworkCore;
using ServicoDomestico.Autenticacao.Domain.Interfaces;
using ServicoDomestico.Autenticacao.Domain.Models.Usuario;
using ServicoDomestico.Autenticacao.Infrastructure.Data.Context;
using ServicoDomestico.Autenticacao.Infrastructure.Data.Repositories;

namespace ServicoDomestico.Autenticacao.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Domain.Models.Usuario.Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(AutenticacaoDbContext contexto) : base(contexto)
        { }

        public async Task<Domain.Models.Usuario.Usuario> Logar(string userName, string senha)
        {
            return await base.Obter(x => x.Username == userName && x.Senha == senha);
        }

        public async Task<Domain.Models.Usuario.Usuario> Cadastrar(Domain.Models.Usuario.Usuario usuario)
        {
           return await base.Adicionar(usuario);
        }
    }
}
