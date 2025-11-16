namespace ServicoAutenticacao.Domain.Entities.Base
{
    public abstract class Entidade
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
