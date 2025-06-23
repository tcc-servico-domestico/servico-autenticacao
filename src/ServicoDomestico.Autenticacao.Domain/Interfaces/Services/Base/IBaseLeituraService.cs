using System.Linq.Expressions;

namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Services.Base
{
    public interface IBaseLeituraService<T> where T : class
    {
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> where);
        Task<T> Obter(Expression<Func<T, bool>> where);

        Task<TResult> Obter<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao,
            bool asNoTracking = false);
        Task<TResult> Obter<TResult, TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao,
            bool asNoTracking = false, Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false);

        Task<TResult> Obter<TResult>(Expression<Func<T, bool>> where, ICollection<string> inclusoes,
            Expression<Func<T, TResult>> projecao,
            bool asNoTracking = false);
        Task<ICollection<TResult>> Buscar<TResult>(Expression<Func<T, bool>> where,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false);

        Task<ICollection<TResult>> Buscar<TResult, TKey>(Expression<Func<T, bool>> where,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false,
            Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false);

        Task<ICollection<TResult>> Buscar<TResult>(Expression<Func<T, bool>> where, ICollection<string> inclusoes,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false);

        Task<ICollection<TResult>> Buscar<TResult, TKey>(Expression<Func<T, bool>> where, ICollection<string> inclusoes,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false,
            Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false);

        Task<bool> ExisteAsync(Expression<Func<T, bool>> predicate);
    }
}
