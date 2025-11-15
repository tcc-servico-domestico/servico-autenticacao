using System.Data;

namespace ServicoAutenticacao.Domain.Interfaces.Context
{
    public interface IDomainDbContext
    {
        IDbConnection RetornaNovaConexao();
        IDbConnection RetornaNovaConexao(string connectionString);
        IDbConnection RetornaConexao();
        Task BeginTranAsync();
        Task Commit();
        Task Rollback();
    }
}
