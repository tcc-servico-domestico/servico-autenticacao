using ServicoDomestico.Autenticacao.Application.ViewModel.Possui;

namespace ServicoDomestico.Autenticacao.Application.ViewModel.Usuario
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public Guid PessoaId { get; set; }

        public string Username { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }

        public ICollection<PossuiViewModel> Permissoes { get; set; }
    }
}