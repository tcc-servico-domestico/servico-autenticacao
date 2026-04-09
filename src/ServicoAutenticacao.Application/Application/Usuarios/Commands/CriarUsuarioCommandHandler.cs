using ServicoAutenticacao.Application.Abstractions;
using ServicoAutenticacao.Domain.Entities;
using ServicoAutenticacao.Domain.Interfaces.Services;

namespace ServicoAutenticacao.Application.Usuarios.Commands
{
    public class CriarUsuarioCommandHandler : ICommandHandler<CriarUsuarioCommand, Dtos.CadastrarUsuarioResponseDto>
    {
        private readonly IUsuarioService _usuarioService;

        public CriarUsuarioCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<Dtos.CadastrarUsuarioResponseDto> HandleAsync(CriarUsuarioCommand command, CancellationToken cancellationToken = default)
        {
            var usuario = await _usuarioService.AdicionarAsync(new Usuario
            {
                Email = command.Email,
                Senha = command.Senha,
                Ativo = false,
                EmailVerificado = false
            });

            return usuario.ToCadastroResponseDto();
        }
    }
}
