using ServicoAutenticacao.Infra.CrossCutting.AppSettings.Mensageria;

namespace ServicoAutenticacao.Infra.CrossCutting.AppSettings
{
    public class MensageriaAppSettings
    {
        public KafkaAppSettings? Kafka { get; set; }
    }
}
