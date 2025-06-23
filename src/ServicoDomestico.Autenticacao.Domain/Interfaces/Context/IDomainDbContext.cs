using System.Data;

namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Context
{
    public interface IDomainDbContext
    {
        /// <summary>
        /// Persiste as altera��es feitas no contexto
        /// </summary>
        /// <param name="cancellationToken">Token que indica se a opera��o deve ser cancelado ou n�o</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Inicia uma nova transa��o no contexto
        /// </summary>
        /// <param name="cancellationToken">Token que indica se a opera��o deve ser cancelado ou n�o</param>
        /// <returns></returns>
        Task BeginTranAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Confirma as altera��es da transa��o atual do contexto na base de dados
        /// </summary>
        /// <param name="cancellationToken">Token que indica se a opera��o deve ser cancelado ou n�o</param>
        /// <returns></returns>
        Task CommitTranAsync(CancellationToken cancellationToken = default);
        /// <summary>
        ///  Descarta as altera��es da transa��o atual do contexto na base de dados
        /// </summary>
        /// <param name="cancellationToken">Token que indica se a opera��o deve ser cancelado ou n�o</param>
        /// <returns></returns>
        Task RollbackTranAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Retorna uma nova conex�o independente.
        /// Essa conex�o deve receber dispose
        /// </summary>
        /// <returns>Uma inst�ncia da implementa��o de IDbConnection</returns>
        IDbConnection RetornaNovaConexao();
        /// <summary>
        /// Retorna uma nova conex�o independente.
        /// Essa conex�o deve receber dispose
        /// </summary>
        /// <returns>Uma inst�ncia da implementa��o de IDbConnection</returns>
        IDbConnection RetornaNovaConexao(string stringDeConexao);
        /// <summary>
        /// Essa conex�o � a conex�o do EF
        /// Essa conex�o n�o deve receber dispose
        /// </summary>
        /// <returns>Uma inst�ncia da implementa��o de IDbConnection</returns>
        IDbConnection RetornaConexao();
        //Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters);
        //Task<int> ExecuteSqlRawAsync(string sql, IEnumerable<object> parameters,
        //    CancellationToken cancellationToken = default);
        //Task<int> ExecuteSqlRawAsync(string sql, CancellationToken cancellationToken = default);
    }
}