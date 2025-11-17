using Confluent.Kafka;
using Microsoft.Extensions.Options;
using ServicoAutenticacao.Domain.Interfaces.Mensageria;
using AppSettings = ServicoAutenticacao.Infra.CrossCutting.AppSettings;

namespace ServicoAutenticacao.Infra.CrossCutting.Mensageria
{
    public class EventProducer : IEventProducer
    {
        private readonly IProducer<Null, string> _producer;

        public EventProducer(IOptions<AppSettings.AppSettings> appSettings)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = appSettings.Value?.Mensageria?.Kafka?.BootstrapServers ?? throw new InvalidOperationException("Kafka não configurado"),
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceAsync(string topico, string mensagem)
        {
            await _producer.ProduceAsync(topico, new Message<Null, string> { Value = mensagem });
        }
    }
}