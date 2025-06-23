using ServicoDomestico.Autenticacao.Application.AppService.Base;
using ServicoDomestico.Autenticacao.Application.Inteface.Usuario;
using ServicoDomestico.Autenticacao.Application.ViewModel.Usuario;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Context;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Services;
using ServicoDomestico.Autenticacao.Domain.Interfaces.UoW;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Utils;

namespace ServicoDomestico.Autenticacao.Application.AppService.Usuario
{
    public class UsuarioAppService : BaseAppService<IAutenticacaoDbContext>, IUsuarioAppService
    {
        private readonly IUsuarioService _service;

        public UsuarioAppService(
            IInjecaoDeDependeciasService injecaoDeDependeciasService,
            IUnitOfWork<IAutenticacaoDbContext> uow)
            : base(injecaoDeDependeciasService, uow)
        {
            injecaoDeDependeciasService.InstanciaDependencia(out _service);
        }

        public async Task<UsuarioViewModel> Logar(string userName, string senha)
        {
            var result = await _service.Logar(userName, senha);
            var usuario = Mapper.Map<UsuarioViewModel>(result);
            
            return usuario;
        }

        public async Task<UsuarioViewModel> Cadastrar(UsuarioViewModel usuario)
        {
            var result = await _service.Cadastrar(Mapper.Map<Domain.Models.Usuario.Usuario>(usuario));

            return Mapper.Map<UsuarioViewModel>(result); 
        }
    }
}