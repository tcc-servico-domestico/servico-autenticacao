using Microsoft.Extensions.DependencyInjection;
using ServicoAutenticacao.Application.Abstractions;
using ServicoAutenticacao.Application.Autenticacao.Commands;
using ServicoAutenticacao.Application.Dtos;
using ServicoAutenticacao.Application.Usuarios.Commands;
using ServicoAutenticacao.Application.Usuarios.Queries;

namespace ServicoAutenticacao.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<ObterUsuarioPorIdQuery, UsuarioDto?>, ObterUsuarioPorIdQueryHandler>();
            services.AddScoped<ICommandHandler<CriarUsuarioCommand, CadastrarUsuarioResponseDto>, CriarUsuarioCommandHandler>();
            services.AddScoped<ICommandHandler<ConfirmarEmailCommand, bool>, ConfirmarEmailCommandHandler>();
            services.AddScoped<ICommandHandler<LoginCommand, UsuarioDto?>, LoginCommandHandler>();

            return services;
        }
    }
}
