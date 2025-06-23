using ServicoDomestico.Autenticacao.Domain.Interfaces.Context;
using ServicoDomestico.Autenticacao.Domain.Interfaces.UoW;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Utils;
using AutoMapper;

namespace ServicoDomestico.Autenticacao.Application.AppService.Base
{
    public abstract class BaseAppService<T> where T : IDomainDbContext
    {
        private readonly IUnitOfWork<T> _ouw;
        protected readonly IMapper Mapper;

        protected BaseAppService(
            IInjecaoDeDependeciasService injecaoDependenciaService,
            IUnitOfWork<T> ouw)
        {
            _ouw = ouw;
            injecaoDependenciaService.InstanciaDependencia(out Mapper);            
        }

        protected async Task BeginTran()
        {
            await _ouw.BeginTran();
        }
        
        protected async Task CommitTran()
        {
            await _ouw.Commit();
            await _ouw.CommitTran();
        }
    }
}