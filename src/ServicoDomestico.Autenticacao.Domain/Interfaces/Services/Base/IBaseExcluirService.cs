namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Services.Base
{
    public interface IBaseExcluirService<T> where T : class
    {
        Task Excluir(T objeto, bool aplicarAlteracoes = false);
        Task Excluir(ICollection<T> lista, bool aplicarAlteracoes = false);
    }
}
