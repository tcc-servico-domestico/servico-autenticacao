using Microsoft.Extensions.DependencyInjection;
using ServicoAutenticacao.Domain.Interfaces.Context;
using ServicoAutenticacao.Domain.Interfaces.Repositories;
using ServicoAutenticacao.Domain.Interfaces.Services;
using ServicoAutenticacao.Domain.Interfaces.Mensageria;
using ServicoAutenticacao.Domain.Services;
using ServicoAutenticacao.Infra.CrossCutting.AppSettings;
using ServicoAutenticacao.Infra.CrossCutting.Mensageria;
using ServicoAutenticacao.Infra.Data.Context;
using ServicoAutenticacao.Infra.Data.Repositories;


namespace ServicoAutenticacao.Infra.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services, AppSettings appSettings)
        {
            services.RegistrarInjecaoDependenciasGerais(appSettings);
            services.RegistrarInjecaoDependenciasRepositories();
            services.RegistrarInjecaoDependenciasServicosDomain();
            services.RegistrarInjecaoDependenciasAppServices();
            services.RegistrarInjecaoDependenciasIntegracoes();

            return services;
        }

        public static void RegistrarInjecaoDependenciasGerais(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddScoped(provider =>
            {
                var service = provider.GetService<IServicoAutenticacaoDbContext>() as ServicoAutenticacaoDbContext;
                return service!;
            });

            services.AddScoped<IServicoAutenticacaoDbContext, ServicoAutenticacaoDbContext>();
        }

        public static void RegistrarInjecaoDependenciasRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        public static void RegistrarInjecaoDependenciasServicosDomain(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();

        }

        public static void RegistrarInjecaoDependenciasAppServices(this IServiceCollection services)
        {
            
        }

        private static void RegistrarInjecaoDependenciasIntegracoes(this IServiceCollection services)
        {
            services.AddSingleton<IEventProducer, EventProducer>();
        }
    }
}
