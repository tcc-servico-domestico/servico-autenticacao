using ServicoAutenticacao.Domain.Entities.Base;

namespace ServicoAutenticacao.Domain.Interfaces.Services.Base
{
    public interface IService<T> where T : Entidade
    {
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<T?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<T>> BuscarAsnc();
        Task<T> AdicionarAsync(T entidade);
        Task<T> AtualizarAsync(T entidade);
        Task<T> ExcluirAsync(Guid id);
    }
}
