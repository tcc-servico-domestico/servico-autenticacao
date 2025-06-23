using ServicoDomestico.Autenticacao.Domain.Interfaces.Context;

namespace ServicoDomestico.Autenticacao.Domain.Interfaces.UoW
{
    public interface IUnitOfWork<T> where T : IDomainDbContext
    {
        Task<int> Commit();
        Task BeginTran();
        Task CommitTran();
        Task RollbackTran();
    }
}