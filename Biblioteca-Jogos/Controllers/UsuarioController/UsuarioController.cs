using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Usuario
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : ControllerBase
    {
      
        private readonly ServiceUsuario _Su;

        public UsuarioController(ServiceUsuario Su)
        {
            _Su = Su;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _Su.GetSU();
            if (usuarios == null)
            {
                return NotFound("Banco vazia");
            }
            return Ok(usuarios);
            
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoRequest request)
        {
            var usuario = await _Su.PostSU(request);
            if (usuario == null)
            {
                return BadRequest("Informações inválidas rapá");
            }
            return Created("",usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            var usuario = await _Su.PutSU(id);
            if (usuario == null)
            {
                return NotFound("Usuario não encontrado");
            }
            return Ok("Usuario atualizado");

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _Su.DeleteSU(id);
            if (usuario == false)
            {
                return NotFound("Usuario não encontrado");
            }
            return Ok("Usuario Deletado");
        }
    }
}
