using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicoAutenticacao.Domain.Entities;
using ServicoAutenticacao.Domain.Interfaces.Services;

namespace ServicoAutenticacao.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _service;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<Usuario?> ObterPorIdAsync(Guid id)
        {
            var retorno = await _service.ObterPorIdAsync(id);
            return retorno;
        }

        [HttpPost]
        public async Task<Usuario> AdicionarAsync([FromBody] Usuario entidade)
        {
            return await _service.AdicionarAsync(entidade);
        }

        [HttpGet("confirmar-email/{token}")]
        [AllowAnonymous]
        public async Task ConfirmarEmailAsync(string token)
        {
            await _service.ConfirmarEmailAsync(token);
        }
    }
}
