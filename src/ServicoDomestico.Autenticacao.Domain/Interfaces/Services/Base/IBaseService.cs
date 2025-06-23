namespace ServicoDomestico.Autenticacao.Domain.Interfaces.Services.Base
{
    public interface IBaseService<T> : IBaseLeituraService<T>, IBaseExcluirService<T>, IBaseAtualizarService<T>, IBaseAdicionarService<T> where T : class
    { }
}
