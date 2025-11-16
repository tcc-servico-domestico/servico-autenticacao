using ServicoAutenticacao.Domain.Entities.Base;

namespace ServicoAutenticacao.Domain.Entities
{
    public class Usuario : Entidade
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required bool Ativo { get; set; } = false;
        public required bool EmailVerificado { get; set; } = false;
        public DateTime? DataUltimaAlteracaoSenha { get; set; }

        public void DefinirEmailVerificado()
        {
            EmailVerificado = true;
        }
    }
}
