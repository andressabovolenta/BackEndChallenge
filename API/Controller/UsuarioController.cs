using BackEndChallenge.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> ValidarSenha([FromQuery] string senha)
        {
            var response =  await _usuarioService.ValidarSenha(senha);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
