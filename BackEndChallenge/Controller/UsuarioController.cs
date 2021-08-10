using BackEndChallenge.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BackEndChallenge.Controller
{
    [Route("[controller]")]
    public class UsuarioController
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("validarSenha")]
        public IActionResult ValidarSenha([FromQuery] string senha)
        {
            var response = _usuarioService.ValidarSenha(senha);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
