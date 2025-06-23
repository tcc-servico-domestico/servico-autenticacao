using System.Linq.Expressions;

namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Repositories.Base
{
    public interface IBaseLeituraRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> where, bool asNoTracking = false);
        Task<T> Obter(Expression<Func<T, bool>> where, bool asNoTracking = false);
        Task<TResult> Obter<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao,
            bool asNoTracking = false);
        Task<TResult> Obter<TResult>(Expression<Func<T, bool>> where, ICollection<string> inclusoes,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false);
        Task<TResult> Obter<TResult, TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao,
            bool asNoTracking = false, Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false);
        Task<ICollection<TResult>> Buscar<TResult>(Expression<Func<T, bool>> where,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false);

        Task<ICollection<TResult>> Buscar<TResult, TKey>(Expression<Func<T, bool>> where,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false,
            Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false);
        Task<IEnumerable<T>> Buscar(string tsql, object parametros = null);
        Task<T> Obter(string tsql, object parametros = null);
        Task<TT> Obter<TT>(string tsql, object parametros = null);
        
        Task<bool> ExisteCadastro(string query, object parametros = null);

        Task<ICollection<TResult>> Buscar<TResult>(Expression<Func<T, bool>> where, ICollection<string> inclusoes,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false);

        Task<ICollection<TResult>> Buscar<TResult, TKey>(Expression<Func<T, bool>> where, ICollection<string> inclusoes,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false,
            Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false);

        Task<bool> ExisteAsync(Expression<Func<T, bool>> predicate);
    }
}