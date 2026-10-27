using Biblioteca_Usuario;
using Biblioteca_Jogos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Biblioteca_Jogos.DTOS.DtoLista;
using Microsoft.AspNetCore.Authorization;
namespace Biblioteca_Usuario
{

    [ApiController]
    [Route("api/[Controller]")]
    public class ListaController : ControllerBase
    {
        private readonly ServiceLista _Sl;
        private readonly ServiceJogo _Sj;

        private readonly ServiceUsuario _Su;

        public ListaController(ServiceLista Sl, ServiceJogo Sj, ServiceUsuario Su)
        {
            _Sl = Sl;
            _Sj = Sj;
            _Su = Su;
        }
        [Authorize(Roles = "Usuario")]
        [HttpPost("Lista")]

        public async Task<IActionResult> Post([FromForm]ListaDto lista)
        {
            var email = User.FindFirst(ClaimTypes.Name)?.Value;
            
            var Usuario = await _Su.FirstOrDefault(email!);

            if (Usuario == null)
            {
                return NotFound("Usuario não encontrado");
            }

            await _Sl.PostSl(lista,email!);

            return Ok("Jogo adicionado na sua lista.");




            

        }

        [Authorize(Roles = "Usuario")]

        [HttpGet("Meus Jogos")]

        public async Task<IActionResult> Get()
        {
            var Email = User.FindFirst(ClaimTypes.Name)?.Value;

           if (Email == null)
            {
                return NotFound("Usuario não encontrado");
            }
          


           var lista = await _Sl.GetSL(Email!);
            if (lista == null)
            {
                return NotFound("Erro");
            }

            return Ok(lista);

        }
    }
}
