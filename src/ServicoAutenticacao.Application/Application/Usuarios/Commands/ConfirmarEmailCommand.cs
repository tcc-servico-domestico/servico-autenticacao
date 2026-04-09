using ServicoAutenticacao.Application.Abstractions;

namespace ServicoAutenticacao.Application.Usuarios.Commands
{
    public record ConfirmarEmailCommand(string Token) : ICommand<bool>;
}

