namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Services.Base
{
    public interface IBaseAdicionarService<T> where T : class
    {
        Task<ICollection<T>> Adicionar(ICollection<T> lista, bool aplicarAlteracoes = false);
        Task<T> Adicionar(T objeto, bool aplicarAlteracoes = false);
    }
}
