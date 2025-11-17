namespace ServicoAutenticacao.Domain.Entities
{
    public class Notificacao
    {
        public required Guid CanalId { get; set; }
        public required Guid TemplateId { get; set; }
        public required string Titulo { get; set; }
        public required string Mensagem { get; set; }
        public required DateTime DataAgendamento { get; set; } 
        public DateTime? DataEnvio { get; set; }
        public DateTime? DataCriacao { get; set; } = DateTime.UtcNow;
        public required int MaxTentativas { get; set; }
        public required Guid PessoaId { get; set; }
    }
}
