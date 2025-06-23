using Microsoft.AspNetCore.Mvc;
using ServicoDomestico.Autenticacao.Api.Controllers.Base;

namespace ServicoDomestico.Autenticacao.Api.Controllers.Usuario
{
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> ObterTodos()
        {
            return new string[] {"teste 1", "teste 2"};
        }
    }
}