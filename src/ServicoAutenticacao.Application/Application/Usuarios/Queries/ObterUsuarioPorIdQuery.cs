using ServicoAutenticacao.Application.Abstractions;

namespace ServicoAutenticacao.Application.Usuarios.Queries
{
    public record ObterUsuarioPorIdQuery(Guid UsuarioId) : IQuery<Dtos.UsuarioDto?>;
}

