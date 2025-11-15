namespace ServicoAutenticacao.Domain.Entities.Base
{
    public abstract class Entidade
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
