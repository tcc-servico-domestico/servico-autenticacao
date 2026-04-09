using ServicoAutenticacao.Application.Dtos;
using ServicoAutenticacao.Domain.Entities;

namespace ServicoAutenticacao.Application.Usuarios
{
    public static class UsuarioDtoMapper
    {
        public static CadastrarUsuarioResponseDto ToCadastroResponseDto(this Usuario usuario)
        {
            return new CadastrarUsuarioResponseDto
            {
                Id = usuario.Id,
                Email = usuario.Email
            };
        }

        public static UsuarioDto ToDto(this Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Ativo = usuario.Ativo,
                EmailVerificado = usuario.EmailVerificado
            };
        }
    }
}

