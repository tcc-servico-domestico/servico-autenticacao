using ServicoAutenticacao.Application.Abstractions;
using ServicoAutenticacao.Application.Usuarios;
using ServicoAutenticacao.Domain.Interfaces.Services;

namespace ServicoAutenticacao.Application.Autenticacao.Commands
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, Dtos.UsuarioDto?>
    {
        private readonly IUsuarioService _usuarioService;

        public LoginCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<Dtos.UsuarioDto?> HandleAsync(LoginCommand command, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(command.Usuario) || string.IsNullOrWhiteSpace(command.Senha))
                return null;

            var usuario = (await _usuarioService.BuscarAsync(x => x.Email == command.Usuario && x.Senha == command.Senha)).FirstOrDefault();
            if (usuario is null)
                return null;

            if (!usuario.EmailVerificado || !usuario.Ativo)
                return null;

            return usuario.ToDto();
        }
    }
}

