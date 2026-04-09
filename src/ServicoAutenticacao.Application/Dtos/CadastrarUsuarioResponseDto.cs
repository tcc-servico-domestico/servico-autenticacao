namespace ServicoAutenticacao.Application.Dtos
{
    public class CadastrarUsuarioResponseDto
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
    }
}
