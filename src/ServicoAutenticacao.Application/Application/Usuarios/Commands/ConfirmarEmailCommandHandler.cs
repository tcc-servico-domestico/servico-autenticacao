using ServicoAutenticacao.Application.Abstractions;
using ServicoAutenticacao.Domain.Interfaces.Services;

namespace ServicoAutenticacao.Application.Usuarios.Commands
{
    public class ConfirmarEmailCommandHandler : ICommandHandler<ConfirmarEmailCommand, bool>
    {
        private readonly IUsuarioService _usuarioService;

        public ConfirmarEmailCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<bool> HandleAsync(ConfirmarEmailCommand command, CancellationToken cancellationToken = default)
        {
            await _usuarioService.ConfirmarEmailAsync(command.Token);
            return true;
        }
    }
}

