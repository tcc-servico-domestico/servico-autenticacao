using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicoAutenticacao.Application.Abstractions;
using ServicoAutenticacao.Application.Autenticacao.Commands;
using ServicoAutenticacao.Application.Dtos;

namespace ServicoAutenticacao.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly ICommandHandler<LoginCommand, UsuarioDto?> _loginCommandHandler;

        public AutenticacaoController(ICommandHandler<LoginCommand, UsuarioDto?> loginCommandHandler)
        {
            _loginCommandHandler = loginCommandHandler;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioDto>> LoginAsync([FromBody] LoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Usuario) || string.IsNullOrWhiteSpace(dto.Senha))
                return BadRequest("UsuÃ¡rio e senha sÃ£o obrigatÃ³rios.");

            var usuario = await _loginCommandHandler.HandleAsync(new LoginCommand(dto.Usuario, dto.Senha));
            if (usuario is null)
                return Unauthorized();

            return Ok(usuario);
        }
    }
}

