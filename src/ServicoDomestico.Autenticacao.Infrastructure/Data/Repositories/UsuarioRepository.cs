using Microsoft.EntityFrameworkCore;
using ServicoDomestico.Autenticacao.Domain.Interfaces;
using ServicoDomestico.Autenticacao.Infrastructure.Data;

namespace ServicoDomestico.Autenticacao.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.Usuario.Usuario>> Logar(string userName, string senha)
        {
            return await _context.();
        }

        public async Task<Domain.Models.Usuario.Usuario> Cadastrar(Domain.Models.Usuario.Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
