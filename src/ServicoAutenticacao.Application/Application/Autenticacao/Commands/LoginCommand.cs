using ServicoAutenticacao.Application.Abstractions;

namespace ServicoAutenticacao.Application.Autenticacao.Commands
{
    public record LoginCommand(string Usuario, string Senha) : ICommand<Dtos.UsuarioDto?>;
}

