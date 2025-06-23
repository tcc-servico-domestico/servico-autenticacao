using System.Data;

namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Context
{
    public interface IDomainDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTranAsync(CancellationToken cancellationToken = default);
        Task CommitTranAsync(CancellationToken cancellationToken = default);
        Task RollbackTranAsync(CancellationToken cancellationToken = default);
        IDbConnection RetornaNovaConexao();
        IDbConnection RetornaNovaConexao(string stringDeConexao);
        IDbConnection RetornaConexao();
        Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters);
        Task<int> ExecuteSqlRawAsync(string sql, IEnumerable<object> parameters,
            CancellationToken cancellationToken = default);
        Task<int> ExecuteSqlRawAsync(string sql, CancellationToken cancellationToken = default);
    }
}