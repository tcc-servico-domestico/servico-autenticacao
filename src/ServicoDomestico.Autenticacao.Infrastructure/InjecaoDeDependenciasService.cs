using Microsoft.Extensions.DependencyInjection;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Utils;

namespace ServicoDomestico.Autenticacao.Infrastructure
{
    public class InjecaoDeDependeciasService(IServiceProvider serviceProvider) : IInjecaoDeDependeciasService
    {
        public void InstanciaDependencia<T>(out T interfaceParaInstancia) => interfaceParaInstancia = serviceProvider.GetService<T>();
        public T ObterInstancia<T>() => serviceProvider.GetService<T>();
    }
}