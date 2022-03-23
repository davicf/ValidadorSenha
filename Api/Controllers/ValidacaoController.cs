using Aplicacao.ValidarSenha;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("validacoes")]
    [ApiController]
    public class ValidacaoController : ControllerBase
    {
        private readonly IValidarSenhaCasoDeUso _validarSenhaCasoDeUso;

        public ValidacaoController(IValidarSenhaCasoDeUso validarSenhaCasoDeUso)
        {
            _validarSenhaCasoDeUso = validarSenhaCasoDeUso;
        }

        [HttpGet("{senha}")]
        public IActionResult ValidarSenha(string senha)
        {
            _validarSenhaCasoDeUso.ValidarSenha(new ValidarSenhaDto { Senha = senha });

            return Ok();
        }
    }
}