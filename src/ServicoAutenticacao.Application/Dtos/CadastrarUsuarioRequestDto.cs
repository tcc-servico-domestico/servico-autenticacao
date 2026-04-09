namespace ServicoAutenticacao.Application.Dtos
{
    public class CadastrarUsuarioRequestDto
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
