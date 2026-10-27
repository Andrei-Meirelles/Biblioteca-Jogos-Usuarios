using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Jogos.Controllers.JogoController
{
    [ApiController]
    [Route("api/[Controller]")]

    public class JogoController : ControllerBase
    {

        private readonly ServiceJogo _Sj;

        public JogoController(ServiceJogo Sj)
        {
            _Sj = Sj;
        }

        [Authorize(Roles = "Usuario")]
        [HttpGet]

        public async Task<IActionResult> GetJ()
        {
            var jogos = await _Sj.GetSJ();
            if (jogos == null)
            {
                return NotFound("Lista vazia");
            }
            return Ok(jogos);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<IActionResult> PostJ([FromForm]JogoRequest jogodto)
        {
            var jogo = await _Sj.PostSJ(jogodto);
            if (jogo == null)
            {
                return BadRequest("Jogo inválido");
            }
            return Created("", jogo);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJ([FromForm]JogoRequest jogodto,int id)
        {
            var jogo = await _Sj.PutSJ(jogodto,id);
            if (jogo == null)
            {
                return NotFound("Jogo não encontrado");

            }

            return Ok("jogo atualizado");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJ(int id)
        {
            var jogo = await _Sj.DeleteSJ(id);

            if(jogo == false)
            {
                return NotFound("Jogo não encontrado");
            }
            return Ok("Jogo deletado");
        }

        [Authorize(Roles = "Usuario")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetidJ(int id)
        {
            var jogo = await _Sj.GetIdSJ(id);
            if(jogo == null)
            {
                return NotFound("Jogo não encontrado");
            }
            return Ok(jogo);
        }
        


        
    }
}
