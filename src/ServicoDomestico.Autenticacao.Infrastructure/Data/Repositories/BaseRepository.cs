using System.Data;
using Dapper;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Context;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Repositories.Base;

namespace ServicoDomestico.Autenticacao.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseEscritaRepository<T>, IBaseLeituraRepository<T> where T : class
    {
        protected DomainDbContext Contexto;
        protected DbSet<T> Entidades;
        private IDbContextTransaction _transacaoAtiva;
        protected readonly string ConnectionStringContexto;

        protected BaseRepository(DomainDbContext contexto)
        {
            Contexto = contexto;
            Entidades = contexto.Set<T>();

            try
            {
                ConnectionStringContexto = Contexto.Database.GetConnectionString();
            }
            catch
            {
                ConnectionStringContexto = null;
            }
        }

        public virtual async Task<T> Adicionar(T obj, bool aplicarAlteracoes = false)
        {
            EntityEntry<T> objRetorno = await Entidades.AddAsync(obj);
            if (aplicarAlteracoes) await SaveChanges();
            return objRetorno.Entity;
        }

        public virtual async Task<T> Atualizar(T obj, bool aplicarAlteracoes = false)
        {
            EntityEntry<T> objetoRetorno = await Task.Run(() => Entidades.Update(obj));
            if (aplicarAlteracoes) await SaveChanges();
            return objetoRetorno.Entity;
        }

        public virtual async Task Excluir(T obj, bool aplicarAlteracoes = false)
        {
            await Task.Run(() => Entidades.Remove(obj));
            if (aplicarAlteracoes) await SaveChanges();
        }

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await Entidades.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> where, bool asNoTracking = false)
        {
            if (asNoTracking) return await Entidades.AsNoTracking().Where(where).ToListAsync();
            return await Entidades.Where(where).ToListAsync();
        }

        public virtual async Task<T> Obter(Expression<Func<T, bool>> where, bool asNoTracking = false)
        {
            if (asNoTracking) return await Entidades.AsNoTracking().FirstOrDefaultAsync(where);
            return await Entidades.FirstOrDefaultAsync(where);
        }

        public virtual async Task<TResult> Obter<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao, bool asNoTracking = false)
        {
            if (asNoTracking) return await Entidades.AsNoTracking().Where(where).Select(projecao).FirstOrDefaultAsync();
            return await Entidades.Where(where).Select(projecao).FirstOrDefaultAsync();
        }

        public virtual async Task<TResult> Obter<TResult>(Expression<Func<T, bool>> where, ICollection<string> inclusoes, Expression<Func<T, TResult>> projecao, bool asNoTracking = false)
        {
            var query = Entidades.AsQueryable();

            if (inclusoes != null && inclusoes.Any())
                query = inclusoes.Aggregate(query, (current, x) => current.Include(x));

            if (asNoTracking) return await query.AsNoTracking().Where(where).Select(projecao).FirstOrDefaultAsync();
            return await query.Where(where).Select(projecao).FirstOrDefaultAsync();
        }

        public virtual async Task<ICollection<TResult>> Buscar<TResult>(Expression<Func<T, bool>> where, ICollection<string> inclusoes, Expression<Func<T, TResult>> projecao, bool asNoTracking = false)
        {
            var query = Entidades.AsQueryable();

            if (inclusoes != null && inclusoes.Any())
                query = inclusoes.Aggregate(query, (current, x) => current.Include(x));

            if (asNoTracking) return await query.AsNoTracking().Where(where).Select(projecao).ToArrayAsync();
            return await query.Where(where).Select(projecao).ToArrayAsync();
        }

        public virtual async Task<ICollection<TResult>> Buscar<TResult, TKey>(Expression<Func<T, bool>> where, ICollection<string> inclusoes, Expression<Func<T, TResult>> projecao, bool asNoTracking = false, Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false)
        {
            var query = asNoTracking ? Entidades.AsNoTracking().Where(where) : Entidades.Where(where);

            if (inclusoes != null && inclusoes.Any())
                query = inclusoes.Aggregate(query, (current, x) => current.Include(x));

            var querySelect = query.Select(projecao);

            if (orderBy != null)
                querySelect = orderByDesc ? querySelect.OrderByDescending(orderBy) : querySelect.OrderBy(orderBy);

            return await querySelect.ToListAsync();
        }

        public virtual async Task<TResult> Obter<TResult, TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao, bool asNoTracking = false, Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false)
        {
            var query = asNoTracking ? Entidades.AsNoTracking().Where(where) : Entidades.Where(where);

            var querySelect = query.Select(projecao);
            if (orderBy != null)
                querySelect = orderByDesc ? querySelect.OrderByDescending(orderBy) : querySelect.OrderBy(orderBy);

            return await querySelect.FirstOrDefaultAsync();
        }

        public virtual async Task<ICollection<TResult>> Buscar<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao, bool asNoTracking = false)
        {
            if (asNoTracking) return await Entidades.AsNoTracking().Where(where).Select(projecao).ToListAsync();
            return await Entidades.Where(where).Select(projecao).ToListAsync();
        }

        public virtual async Task<ICollection<TResult>> Buscar<TResult, TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao, bool asNoTracking = false, Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false)
        {
            var query = asNoTracking ? Entidades.AsNoTracking().Where(where) : Entidades.Where(where);
            var querySelect = query.Select(projecao);

            if (orderBy != null)
                querySelect = orderByDesc ? querySelect.OrderByDescending(orderBy) : querySelect.OrderBy(orderBy);

            return await querySelect.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Buscar(string tsql, object parametros = null)
        {
            using var cn = RetornaNovaConexao();
            cn.Open();
            return await cn.QueryAsync<T>(tsql, parametros);
        }

        public virtual async Task<T> Obter(string tsql, object parametros = null)
        {
            using var cn = RetornaNovaConexao();
            cn.Open();
            return await cn.QueryFirstAsync<T>(tsql, parametros);
        }

        public virtual async Task<TT> Obter<TT>(string tsql, object parametros = null)
        {
            using var cn = RetornaNovaConexao();
            cn.Open();
            return await cn.QueryFirstOrDefaultAsync<TT>(tsql, parametros);
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

        public virtual async Task<bool> ExisteCadastro(string query, object parametros = null)
        {
            query = @$"SELECT ISNULL(({query}), 0)";
            var existe = await Obter<bool>(query, parametros);
            return existe;
        }

        public virtual async Task<bool> ExisteAsync(Expression<Func<T, bool>> predicate)
        {
            return await Entidades.AsNoTracking().AnyAsync(predicate);
        }

        protected IDbConnection RetornaNovaConexao() => Contexto.RetornaNovaConexao();
        protected IDbConnection RetornaConexao() => Contexto.RetornaConexao();

        public void Dispose()
        {
            _transacaoAtiva?.Dispose();
        }
    }
}
