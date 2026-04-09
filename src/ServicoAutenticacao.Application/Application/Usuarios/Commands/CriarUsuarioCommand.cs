using ServicoAutenticacao.Application.Abstractions;
namespace ServicoAutenticacao.Application.Usuarios.Commands
{
    public record CriarUsuarioCommand(string Email, string Senha) : ICommand<Dtos.CadastrarUsuarioResponseDto>;
}

