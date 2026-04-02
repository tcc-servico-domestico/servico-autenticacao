namespace ServicoAutenticacao.Domain.Entities
{
    public class Endereco
    {
        public required string Valor { get; set; }
        public Guid TipoId { get; set; }
    }
}
