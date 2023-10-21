

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace rpgapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagemController : ControllerBase
    {

        private readonly IPersonagemService _personagemService;

        public PersonagemController(IPersonagemService personagemService)
        {

            _personagemService = personagemService;

        }
        [AllowAnonymous]
        [HttpGet("pegartodos")]
        public async Task<ActionResult<ServiceResposta<List<GetPersonagemDto>>>> GetTodos()
        {
            return Ok(await _personagemService.PegarTodosPersonagens());
        }

        [HttpGet("pergarporid/{id}")]
        public async Task<ActionResult<ServiceResposta<GetPersonagemDto>>> GetUm(int id)
        {
            return Ok(await _personagemService.GetPersonagemPorId(id));
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<ServiceResposta<List<GetPersonagemDto>>>> AddPersonagem(AddPersonagemDto NovoPersonagem)
        {
            return Ok(await _personagemService.AddPersonagem(NovoPersonagem));
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<ServiceResposta<List<GetPersonagemDto>>>> AtualizarPersonagem(AtualizarPersonagemDto PersonagemAtualizado)
        {
            var resposta = await _personagemService.AtualizarPersonagem(PersonagemAtualizado);
            if (resposta.Dados is null)
            {
                return NotFound(resposta);
            }

            return Ok(resposta);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ServiceResposta<GetPersonagemDto>>> DeletarPersonagem(int id)
        {
            var resposta = await _personagemService.DeletarPersonagem(id);
            if (resposta.Dados is null)
            {
                return NotFound(resposta);
            }

            return Ok(resposta);
        }
    }
}