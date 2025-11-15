namespace ServicoAutenticacao.Infra.CrossCutting.AppSettings.Mensageria
{
    public class KafkaAppSettings
    {
        public string? GroupId { get; set; }
        public string? BootstrapServers { get; set; }
    }
}
