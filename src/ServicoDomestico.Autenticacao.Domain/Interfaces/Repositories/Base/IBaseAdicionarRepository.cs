namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Repositories.Base
{
    public interface IBaseAdicionarRepository<T>: IBaseTransacaoRepository<T> where T : class
    {
        Task<T> Adicionar(T obj, bool aplicarAlteracoes);
    }
}