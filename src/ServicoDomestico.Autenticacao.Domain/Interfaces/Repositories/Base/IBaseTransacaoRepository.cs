namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Repositories.Base
{
    public interface IBaseTransacaoRepository<T>: IDisposable where T : class
    {
        Task<int> SaveChanges();
        Task BeginTran();
        Task CommitTran();
        Task RollbackTran();
    }
}