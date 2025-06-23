using System.Data;

namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Context
{
    public interface IDomainDbContext
    {
        /// <summary>
        /// Persiste as alterações feitas no contexto
        /// </summary>
        /// <param name="cancellationToken">Token que indica se a operação deve ser cancelado ou não</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Inicia uma nova transação no contexto
        /// </summary>
        /// <param name="cancellationToken">Token que indica se a operação deve ser cancelado ou não</param>
        /// <returns></returns>
        Task BeginTranAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Confirma as alterações da transação atual do contexto na base de dados
        /// </summary>
        /// <param name="cancellationToken">Token que indica se a operação deve ser cancelado ou não</param>
        /// <returns></returns>
        Task CommitTranAsync(CancellationToken cancellationToken = default);
        /// <summary>
        ///  Descarta as alterações da transação atual do contexto na base de dados
        /// </summary>
        /// <param name="cancellationToken">Token que indica se a operação deve ser cancelado ou não</param>
        /// <returns></returns>
        Task RollbackTranAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Retorna uma nova conexão independente.
        /// Essa conexão deve receber dispose
        /// </summary>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        IDbConnection RetornaNovaConexao();
        /// <summary>
        /// Retorna uma nova conexão independente.
        /// Essa conexão deve receber dispose
        /// </summary>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        IDbConnection RetornaNovaConexao(string stringDeConexao);
        /// <summary>
        /// Essa conexão é a conexão do EF
        /// Essa conexão não deve receber dispose
        /// </summary>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        IDbConnection RetornaConexao();
        //Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters);
        //Task<int> ExecuteSqlRawAsync(string sql, IEnumerable<object> parameters,
        //    CancellationToken cancellationToken = default);
        //Task<int> ExecuteSqlRawAsync(string sql, CancellationToken cancellationToken = default);
    }
}