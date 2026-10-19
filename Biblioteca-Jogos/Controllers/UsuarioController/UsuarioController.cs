using Biblioteca_Jogos;
using Biblioteca_Usuario;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm]LoginDto login)
        {
            var usuario = await _Su.Login(login);
            if (usuario == null)
            {
                return NotFound("usuario não encontrado");
            }
            return Ok(usuario);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _Su.GetSU();
            if (usuarios == null)
            {
                return NotFound("Banco vazio");
            }
            return Ok(usuarios);
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]DtoRequest request)
        {
            var usuario = await _Su.PostSU(request);
            if (usuario == null)
            {
                return BadRequest("Informações inválidas rapá");
            }
            return Created("",usuario);
        }
        [Authorize(Roles = "Usuario")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromForm]DtoRequest usuariodto, int id)
        {
            var usuario = await _Su.PutSU(usuariodto, id);
            if (usuario == null)
            {
                return NotFound("Usuario não encontrado");
            }
            return Ok("Usuario atualizado");

        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Usuario")]
        [HttpGet("{id}")]

        public async Task<IActionResult> GetId(int id)
        {
            var usuario = await _Su.GetIdSU(id);
            if(usuario == null)
            {
                return NotFound("Usuario não encontrado");
            }
            return Ok(usuario);
        }
    }
}
