using ServicoDomestico.Autenticacao.Domain.Interfaces.Repositories.Base;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Utils;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Services.Base;
using System.Linq.Expressions;


namespace ServicoDomestico.Autenticacao.Domain.Service
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        private IBaseExcluirRepository<T> _excluirRepository;
        private IBaseAtualizarRepository<T> _atualizarRepository;
        private IBaseAdicionarRepository<T> _adicionarRepository;
        private IBaseLeituraRepository<T> _leituraRepository;

        protected BaseService(IInjecaoDeDependeciasService injecaoDependenciaService)
        {
        }

        protected void DefinirRepositoryEscrita(IBaseEscritaRepository<T> repository)
        {
            DefinirRepositoryAdicionar(repository);
            DefinirRepositoryAtualizar(repository);
            DefinirRepositoryExcluir(repository);
        }


        public abstract void DefinirInstanciasDeRepositorios();

        protected void DefinirRepositoryAdicionar(IBaseAdicionarRepository<T> repository) => _adicionarRepository = repository;

        protected void DefinirRepositoryAtualizar(IBaseAtualizarRepository<T> repository) => _atualizarRepository = repository;

        protected void DefinirRepositoryExcluir(IBaseExcluirRepository<T> repository) => _excluirRepository = repository;

        public void DefinirRepositoryLeitura(IBaseLeituraRepository<T> repository) => _leituraRepository = repository;

        public virtual async Task<T> Adicionar(T objeto,bool aplicarAlteracoes = false)
        {
            if (_adicionarRepository is null) return null!;
            return await _adicionarRepository.Adicionar(objeto, aplicarAlteracoes);
        }

        public virtual async Task<T> Atualizar(T objeto, bool aplicarAlteracoes = false)
        {
            if (_atualizarRepository is null) return null!;
            return await _atualizarRepository.Atualizar(objeto, aplicarAlteracoes);
        }

        public async Task<ICollection<T>> Adicionar(ICollection<T> lista, bool aplicarAlteracoes = false)
        {
            foreach (var x in lista) await Adicionar(x, aplicarAlteracoes);
            return lista;
        }

        public async Task<ICollection<T>> Atualizar(ICollection<T> lista, bool aplicarAlteracoes = false)
        {
            foreach (var x in lista) await Atualizar(x, aplicarAlteracoes);
            return lista;
        }

        public async Task Excluir(ICollection<T> lista, bool aplicarAlteracoes = false)
        {
            foreach (var x in lista) await Excluir(x, aplicarAlteracoes);
        }

        public virtual async Task Excluir(T objeto, bool aplicarAlteracoes)
        {
            if (_excluirRepository is null) return;
            await _excluirRepository.Excluir(objeto, aplicarAlteracoes);
        }

        public virtual async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> where)
        {
            if(_leituraRepository is null) return null!;
            return await _leituraRepository.Buscar(where);
        }

        public virtual async Task<T> Obter(Expression<Func<T, bool>> where)
        {
            if(_leituraRepository is null) return null!;
            return await _leituraRepository.Obter(where!);
        }

        public async Task<TResult> Obter<TResult, TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao, bool asNoTracking = false, Expression<Func<TResult, TKey>> orderBy = null,
            bool orderByDesc = false)
        {
            if (_leituraRepository is null) return default;
            return await _leituraRepository.Obter(where, projecao, asNoTracking, orderBy, orderByDesc);
        }

        public async Task<TResult> Obter<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao,
            bool asNoTracking = false)
        {
            if (_leituraRepository is null) return default;
            return await _leituraRepository.Obter(where, projecao, asNoTracking);
        }

        public async Task<TResult> Obter<TResult>(Expression<Func<T, bool>> where, ICollection<string> inclusoes,Expression<Func<T, TResult>> projecao,
            bool asNoTracking = false)
        {
            if (_leituraRepository is null) return default;
            return await _leituraRepository.Obter(where, inclusoes, projecao, asNoTracking);
        }

        public async Task<ICollection<TResult>> Buscar<TResult, TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao, bool asNoTracking = false, Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false)
        {
            if (_leituraRepository is null) return default;
            return await _leituraRepository.Buscar(where, projecao, asNoTracking, orderBy, orderByDesc);
        }

        public async Task<ICollection<TResult>> Buscar<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> projecao, bool asNoTracking = false)
        {
            if (_leituraRepository is null) return default;
            return await _leituraRepository.Buscar(where, projecao, asNoTracking);
        }

        public async Task<ICollection<TResult>> Buscar<TResult>(Expression<Func<T, bool>> where, ICollection<string> inclusoes,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false)
        {
            if (_leituraRepository is null) return default;
            return await _leituraRepository.Buscar(where, inclusoes, projecao, asNoTracking);
        }

        public async Task<ICollection<TResult>> Buscar<TResult, TKey>(Expression<Func<T, bool>> where,
            ICollection<string> inclusoes,
            Expression<Func<T, TResult>> projecao, bool asNoTracking = false,
            Expression<Func<TResult, TKey>> orderBy = null, bool orderByDesc = false)
        {
            if (_leituraRepository is null) return default;
            return await _leituraRepository.Buscar(where, inclusoes, projecao, asNoTracking, orderBy, orderByDesc);
        }

        public async Task<IEnumerable<string>> BuscarReferenciasChaveEstrangeira(string nomeTabela, string ids,
            string tabelasDesconsiderar)
        {
            if (_leituraRepository is null) return new List<string>();
            return await _leituraRepository.BuscarReferenciasChaveEstrangeira(nomeTabela, ids, tabelasDesconsiderar);
        }

        public Task<int> BuscarContratoGrupoTipo(int contratoTipoId)
        {
            if (_leituraRepository is null) return Task.FromResult(0);
            return _leituraRepository.BuscarContratoGrupoTipo(contratoTipoId);
        }

        public Task<bool> ExisteAsync(Expression<Func<T, bool>> predicate)
        {
            if (_leituraRepository is null) return null;
            return _leituraRepository.ExisteAsync(predicate);
        }
    }
}