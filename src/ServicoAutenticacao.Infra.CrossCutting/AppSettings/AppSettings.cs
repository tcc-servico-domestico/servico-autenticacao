using ServicoAutenticacaoDB.Infra.CrossCutting.AppSettings;

namespace ServicoAutenticacao.Infra.CrossCutting.AppSettings
{
    public class AppSettings
    {
        public ConnectionStringsAppSettings? ConnectionStrings { get; set; }
        public MensageriaAppSettings? Mensageria { get; set; }
    }
}
