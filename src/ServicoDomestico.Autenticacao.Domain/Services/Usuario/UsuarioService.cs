using ServicoDomestico.Autenticacao.Domain.Interfaces;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Services;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Utils;

namespace ServicoDomestico.Autenticacao.Domain.Service.Usuario
{
    public class UsuarioService : BaseService<Models.Usuario.Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IInjecaoDeDependeciasService injecaoDeDependeciasService)
            : base(injecaoDeDependeciasService)
        {
            injecaoDeDependeciasService.InstanciaDependencia(out _repository);
            DefinirInstanciasDeRepositorios();
        }

        public sealed override void DefinirInstanciasDeRepositorios()
        {
            DefinirRepositoryEscrita(_repository);
            DefinirRepositoryLeitura(_repository);
        }

        public async Task<Models.Usuario.Usuario> Logar(string userName, string senha)
        {
            var model = await _repository.Logar(userName, senha);
            return model;
        }

        public async Task<Models.Usuario.Usuario> Cadastrar(Models.Usuario.Usuario usuario, bool aplicarAlteracoes = false)
        {
            var model = await _repository.Adicionar(usuario, aplicarAlteracoes);
            return model;
        }
    }
}
