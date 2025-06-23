namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Repositories.Base
{
    public interface IBaseEscritaRepository<T> : IBaseAdicionarRepository<T>, IBaseAtualizarRepository<T>, IBaseExcluirRepository<T> where T : class
    { }
}