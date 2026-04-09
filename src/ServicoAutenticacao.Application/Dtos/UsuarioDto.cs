namespace ServicoAutenticacao.Application.Dtos
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public bool Ativo { get; set; }
        public bool EmailVerificado { get; set; }
    }
}

