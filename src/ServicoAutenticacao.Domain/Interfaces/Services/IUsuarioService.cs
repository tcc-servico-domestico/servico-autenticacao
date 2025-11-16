using ServicoAutenticacao.Domain.Entities;
using ServicoAutenticacao.Domain.Interfaces.Services.Base;

namespace ServicoAutenticacao.Domain.Interfaces.Services
{
    public interface IUsuarioService : IService<Usuario> 
    {
        Task ConfirmarEmailAsync(string token);
    }
}
