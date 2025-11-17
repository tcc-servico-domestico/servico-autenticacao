using ServicoAutenticacao.Domain.Entities.Base;
using ServicoAutenticacao.Domain.Interfaces.Repositories.Base;
using ServicoAutenticacao.Domain.Interfaces.Services.Base;
using System.Linq.Expressions;

namespace ServicoAutenticacao.Domain.Services.Base
{
    public abstract class Service<T> : IService<T> where T : Entidade
    {
        protected IRepository<T> _repository;

        public Service(IRepository<T> repository) 
        {
            _repository = repository;
        }

        public virtual Task<T> AdicionarAsync(T entidade)
        {
            return _repository.AdicionarAsync(entidade);
        }

        public virtual Task<T> AtualizarAsync(T entidade)
        {
            return _repository.AtualizarAsync(entidade);
        }

        public Task<T> ExcluirAsync(Guid id)
        {
            T entidade = Activator.CreateInstance<T>();
            entidade.Id = id;
            return _repository.ExcluirAsync(entidade);
        }

        public Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> where)
        {
            return _repository.BuscarAsync(where);
        }

        public Task<T?> ObterPorIdAsync(Guid id)
        {
            return _repository.ObterPorIdAsync(id);
        }

        public Task<IEnumerable<T>> ObterTodosAsync()
        {
            return _repository.ObterTodosAsync();
        }
    }
}
