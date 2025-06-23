namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Repositories.Base
{
    public interface IBaseExcluirRepository<T>: IBaseTransacaoRepository<T> where T : class
    {
        Task Excluir(T obj, bool aplicarAlteracoes);
    }
}