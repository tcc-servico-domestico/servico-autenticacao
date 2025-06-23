using Microsoft.AspNetCore.Mvc;


namespace ServicoDomestico.Autenticacao.Api.Controllers.Base
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok( new { success = true, data = result});
            }

            return BadRequest(new { success = false, errors = ObterErros()});
        }

        public bool OperacaoValida()
        {
            // validações
            return true;
        }

        protected string ObterErros()
        {
            return string.Empty;
        }
    }
}