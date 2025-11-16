namespace ServicoAutenticacao.Domain.Interfaces
{
    public interface ICriptografica
    {
        Task<string> Criptografar(byte[] key, string conteudoPuro);
        Task<string> Descriptografar(byte[] key, string conteudoCriptografado);
    }
}
