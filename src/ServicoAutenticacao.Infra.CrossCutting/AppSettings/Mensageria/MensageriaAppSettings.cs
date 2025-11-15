using ServicoAutenticacao.Infra.CrossCutting.AppSettings.Mensageria;

namespace ServicoAutenticacaoDB.Infra.CrossCutting.AppSettings
{
    public class MensageriaAppSettings
    {
        public KafkaAppSettings? Kafka { get; set; }
    }
}
