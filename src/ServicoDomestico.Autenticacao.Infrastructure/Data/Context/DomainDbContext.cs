using Microsoft.EntityFrameworkCore;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoDomestico.Autenticacao.Infrastructure.Data
{
    public abstract class DomainDbContext : DbContext, IDomainDbContext
    {
        protected DomainDbContext(DbContextOptions options)
            : base(options)
        {

        }

        /// <summary>
        /// Retorna uma nova conexão independente.
        /// Essa conexão deve receber dispose
        /// </summary>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        public abstract IDbConnection RetornaNovaConexao();

        /// <summary>
        /// Retorna uma nova conexão independente.
        /// Essa conexão deve receber dispose
        /// </summary>
        /// <param name="stringDeConexao">string de conexão do banco de dados</param>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        public abstract IDbConnection RetornaNovaConexao(string stringDeConexao);

        /// <summary>
        /// Essa conexão é a conexão do EF
        /// Essa conexão não deve receber dispose
        /// </summary>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        public abstract IDbConnection RetornaConexao();

        public async Task BeginTranAsync(CancellationToken cancellationToken = default)
        {
            await Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTranAsync(CancellationToken cancellationToken = default)
        {
            await Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackTranAsync(CancellationToken cancellationToken = default)
        {
            await Database.RollbackTransactionAsync(cancellationToken);
        }
    }
}
