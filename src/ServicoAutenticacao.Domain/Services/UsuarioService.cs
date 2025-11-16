using ServicoAutenticacao.Domain.Entities;
using ServicoAutenticacao.Domain.Interfaces.Services;
using ServicoAutenticacao.Domain.Interfaces.Repositories;
using ServicoAutenticacao.Domain.Services.Base;
using ServicoAutenticacao.Domain.Interfaces;

namespace ServicoAutenticacao.Domain.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        //private readonly ICriptografica _criptografica;
        public UsuarioService(IUsuarioRepository repository) : base(repository) 
        {
            //_criptografica = criptografica;
        }

        public async Task ConfirmarEmailAsync(string token)
        {
            if (string.IsNullOrEmpty(token)) return;

            var usuarioNaoVerificado = (await _repository.BuscarAsync(x => x.Email == token)).FirstOrDefault();
            if (usuarioNaoVerificado is null) return;

            usuarioNaoVerificado.DefinirEmailVerificado();
            await _repository.AtualizarAsync(usuarioNaoVerificado);
        }
    }
}
