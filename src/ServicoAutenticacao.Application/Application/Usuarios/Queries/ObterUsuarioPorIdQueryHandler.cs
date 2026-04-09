using ServicoAutenticacao.Application.Abstractions;
using ServicoAutenticacao.Domain.Interfaces.Services;

namespace ServicoAutenticacao.Application.Usuarios.Queries
{
    public class ObterUsuarioPorIdQueryHandler : IQueryHandler<ObterUsuarioPorIdQuery, Dtos.UsuarioDto?>
    {
        private readonly IUsuarioService _usuarioService;

        public ObterUsuarioPorIdQueryHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<Dtos.UsuarioDto?> HandleAsync(ObterUsuarioPorIdQuery query, CancellationToken cancellationToken = default)
        {
            var usuario = await _usuarioService.ObterPorIdAsync(query.UsuarioId);
            return usuario?.ToDto();
        }
    }
}

