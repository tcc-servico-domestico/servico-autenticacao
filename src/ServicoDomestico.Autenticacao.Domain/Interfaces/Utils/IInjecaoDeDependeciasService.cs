namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Utils
{
    public interface IInjecaoDeDependeciasService
    {
        void InstanciaDependencia<T>(out T interfaceParaInstancia);
        T ObterInstancia<T>();
    }
}

