using Microsoft.AspNetCore.Mvc;
using rpgapi.Data;
using rpgapi.Dtos.Usuario;
using System.Threading.Tasks;
using rpgapi.Models;

namespace rpgapi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<ServiceResposta<int>>> Registrar(RegistroUsuarioDto request)
        {
            var resposta = await _authRepo.Registrar(new Usuario { Username = request.Username }, request.Senha);

            if (!resposta.Sucesso)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResposta<int>>> Login(LoginUsuarioDto request)
        {
            var resposta = await _authRepo.Login(request.Username, request.Senha);

            if (!resposta.Sucesso)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }
    }
}

