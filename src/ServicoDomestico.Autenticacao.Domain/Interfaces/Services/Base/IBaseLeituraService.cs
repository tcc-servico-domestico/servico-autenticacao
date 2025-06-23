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

        Task<int> BuscarContratoGrupoTipo(int contratoTipoId);
        /// <summary>
        /// Verifica se os registros informados pelo campo "ids" da tabela informada pelo campo "nomeTabela" estão referenciados por constraint de chave estrangeira em alguma tabela da base de dados
        /// </summary>
        /// <param name="nomeTabela">Tabela para verificação</param>
        /// <param name="listaIds">lista de ids para verificação separados por vírgula</param>
        /// <param name="tabelasDesconsiderar">lista de tabelas para desconsiderar separadas por vírgula</param>
        /// <returns>Lista com referências ao registro na base de dados</returns>
        Task<IEnumerable<string>> BuscarReferenciasChaveEstrangeira(string nomeTabela, string listaIds,
            string tabelasDesconsiderar);
        Task<ICollection<TResult>> Buscar<TResult>(Expression<Func<T, bool>> where, ICollection<string> inclusoes,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false);

        Task<ICollection<TResult>> Buscar<TResult, TKey>(Expression<Func<T, bool>> where, ICollection<string> inclusoes,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false,
            Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false);

        Task<bool> ExisteAsync(Expression<Func<T, bool>> predicate);
    }
}
