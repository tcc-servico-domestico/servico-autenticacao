namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Services.Base
{
    public interface IBaseAtualizarService<T> where T : class
    {
        Task<ICollection<T>> Atualizar(ICollection<T> lista, bool aplicarAlteracoes = false);
        Task<T> Atualizar(T objeto, bool aplicarAlteracoes = false);
    }
}
