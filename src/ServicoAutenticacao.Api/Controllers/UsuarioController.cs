using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicoAutenticacao.Application.Abstractions;
using ServicoAutenticacao.Application.Usuarios.Commands;
using ServicoAutenticacao.Application.Usuarios.Queries;
using ServicoAutenticacao.Application.Dtos;

namespace ServicoAutenticacao.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IQueryHandler<ObterUsuarioPorIdQuery, UsuarioDto?> _obterUsuarioPorIdQueryHandler;
        private readonly ICommandHandler<CriarUsuarioCommand, CadastrarUsuarioResponseDto> _criarUsuarioCommandHandler;
        private readonly ICommandHandler<ConfirmarEmailCommand, bool> _confirmarEmailCommandHandler;

        public UsuarioController(
            ILogger<UsuarioController> logger,
            IQueryHandler<ObterUsuarioPorIdQuery, UsuarioDto?> obterUsuarioPorIdQueryHandler,
            ICommandHandler<CriarUsuarioCommand, CadastrarUsuarioResponseDto> criarUsuarioCommandHandler,
            ICommandHandler<ConfirmarEmailCommand, bool> confirmarEmailCommandHandler)
        {
            _logger = logger;
            _obterUsuarioPorIdQueryHandler = obterUsuarioPorIdQueryHandler;
            _criarUsuarioCommandHandler = criarUsuarioCommandHandler;
            _confirmarEmailCommandHandler = confirmarEmailCommandHandler;
        }

        [HttpGet("{id}")]
        public async Task<UsuarioDto?> ObterPorIdAsync(Guid id)
        {
            return await _obterUsuarioPorIdQueryHandler.HandleAsync(new ObterUsuarioPorIdQuery(id));
        }

        [HttpPost]
        public async Task<CadastrarUsuarioResponseDto> AdicionarAsync([FromBody] CadastrarUsuarioRequestDto dto)
        {
            return await _criarUsuarioCommandHandler.HandleAsync(new CriarUsuarioCommand(dto.Email, dto.Senha));
        }

        [HttpGet("confirmar-email/{token}")]
        [AllowAnonymous]
        public async Task ConfirmarEmailAsync(string token)
        {
            await _confirmarEmailCommandHandler.HandleAsync(new ConfirmarEmailCommand(token));
        }
    }
}

