using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using ServicoAutenticacao.Domain.Entities.Base;
using ServicoAutenticacao.Domain.Interfaces.Repositories.Base;
using ServicoAutenticacao.Infra.Data.Context;
using System.Data;

namespace ServicoAutenticacao.Infra.Data.Repositories.Base
{
    public abstract class Repository<T> : IDisposable, IRepository<T> where T : Entidade
    {
        protected DomainDbContext Contexto;
        protected DbSet<T> Entidades;
        private IDbContextTransaction? _transacaoAtiva;
        protected readonly string ConnectionStringContexto;

        protected Repository(DomainDbContext contexto)
        {
            Contexto = contexto;
            Entidades = contexto.Set<T>();
            ConnectionStringContexto = Contexto.Database.GetDbConnection().ConnectionString;
        }

        public async Task<IEnumerable<T>> BuscarAsnc()
        {
            return await Entidades.ToListAsync();
        }

        public async Task<T?> ObterPorIdAsync(Guid id)
        {
            return await Entidades.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await Entidades.ToListAsync();
        }

        public async Task<T> AdicionarAsync(T entidade)
        {
            EntityEntry<T> entidadeRetorno = await Entidades.AddAsync(entidade);
            await SaveChanges();
            return entidadeRetorno.Entity;
        }

        public async Task<T> AtualizarAsync(T entidade)
        {
            EntityEntry<T> entidadeRetorno = Entidades.Update(entidade);
            await SaveChanges();
            return entidadeRetorno.Entity;
        }

        public async Task<T> ExcluirAsync(T entidade)
        {
            EntityEntry<T> entidadeRetorno = Entidades.Remove(entidade);
            await SaveChanges();
            return entidadeRetorno.Entity;
        }

        public virtual async Task<int> SaveChanges()
        {
            return await Contexto.SaveChangesAsync();
        }

        public virtual async Task BeginTran()
        {
            _transacaoAtiva = await Contexto.Database.BeginTransactionAsync();
        }

        public virtual async Task CommitTran()
        {
            if (_transacaoAtiva is null) return;
            await _transacaoAtiva.CommitAsync();
            _transacaoAtiva = null;
        }

        public virtual async Task RollbackTran()
        {
            if (_transacaoAtiva is null) return;
            await _transacaoAtiva.RollbackAsync();
            _transacaoAtiva = null;
        }

        protected IDbConnection RetornaNovaConexao() => Contexto.RetornaNovaConexao();

        protected IDbConnection RetornaConexao() => Contexto.RetornaConexao();

        public void Dispose()
        {
            _transacaoAtiva?.Dispose();
            Contexto.Dispose();
        }
    }
}
