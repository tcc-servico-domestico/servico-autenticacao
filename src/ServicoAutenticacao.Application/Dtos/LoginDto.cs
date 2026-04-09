namespace ServicoAutenticacao.Application.Dtos
{
    public class LoginDto
    {
        public required string Usuario { get; set; }
        public required string Senha { get; set; }
    }
}

