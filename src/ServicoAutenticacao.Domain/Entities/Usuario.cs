using ServicoAutenticacao.Domain.Entities.Base;

namespace ServicoAutenticacao.Domain.Entities
{
    public class Usuario : Entidade
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required bool Ativo { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataUltimaAlteracaoSenha { get; set; }
    }
}
