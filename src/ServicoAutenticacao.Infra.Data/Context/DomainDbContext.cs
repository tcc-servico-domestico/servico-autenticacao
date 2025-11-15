using Microsoft.EntityFrameworkCore;
using ServicoAutenticacao.Domain.Interfaces.Context;
using System.Data;

namespace ServicoAutenticacao.Infra.Data.Context
{
    public abstract class DomainDbContext : DbContext, IDomainDbContext
    {
        protected DomainDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public abstract IDbConnection RetornaNovaConexao();
        public abstract IDbConnection RetornaNovaConexao(string connectionString);
        public abstract IDbConnection RetornaConexao();

        public async Task BeginTranAsync()
        {
            await Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await Database.CommitTransactionAsync();
        }

        public async Task Rollback()
        {
            await Database.RollbackTransactionAsync();
        }
    }
}
