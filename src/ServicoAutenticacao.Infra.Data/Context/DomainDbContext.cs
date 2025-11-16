using Microsoft.EntityFrameworkCore;
using ServicoAutenticacao.Domain.Entities.Base;
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

        private void PreencherCriacaoAtualizacao()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Entidade &&
                       (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (Entidade)entry.Entity;

                if (entry.State == EntityState.Added)
                    entity.DataCriacao = DateTime.UtcNow;

                entity.DataAtualizacao = DateTime.UtcNow;
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            PreencherCriacaoAtualizacao();
            return base.SaveChangesAsync(cancellationToken);
        }       
    }
}
