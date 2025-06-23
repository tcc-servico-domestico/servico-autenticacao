namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Repositories.Base
{
    public interface IBaseAtualizarRepository<T>: IBaseTransacaoRepository<T> where T : class
    {
        Task<T> Atualizar(T obj, bool aplicarAlteracoes);
    }
}