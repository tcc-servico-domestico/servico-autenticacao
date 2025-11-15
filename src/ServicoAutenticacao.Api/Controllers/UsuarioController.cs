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

        [HttpGet]
        public async Task<IEnumerable<Usuario>> ObterTodosAsnyc()
        {
            var retorno = await _service.ObterTodosAsync();
            return retorno;
        }

        [HttpGet("{id}")]
        public async Task<Usuario?> ObterPorIdAsync(Guid id)
        {
            var retorno = await _service.ObterPorIdAsync(id);
            return retorno;
        }

        [HttpGet("buscar")]
        public async Task<IEnumerable<Usuario>> BuscarAsync([FromBody] string parametros)
        {
            var retorno = await _service.BuscarAsnc();
            return retorno;
        }

        [HttpPost]
        public async Task AdicionarAsync([FromBody] Usuario entidade)
        {
            await _service.AdicionarAsync(entidade);
        }
    }
}
