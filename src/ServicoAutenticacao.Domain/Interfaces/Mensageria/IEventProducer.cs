namespace ServicoAutenticacao.Domain.Interfaces.Mensageria;

public interface IEventProducer
{
    Task ProduceAsync(string topico, string mensagem);
}
