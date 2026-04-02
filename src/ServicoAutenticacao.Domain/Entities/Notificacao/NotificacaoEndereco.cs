namespace ServicoAutenticacao.Domain.Entities
{
    public class NotificacaoEndereco
    {
        public Guid NotificacaoId { get; init; }
        public Guid EnderecoId { get; init; }

        public virtual Endereco? Endereco { get; init; }
    }
}
