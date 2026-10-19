using Biblioteca_Usuario;
using Biblioteca_Jogos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Biblioteca_Jogos.DTOS.DtoLista;
namespace Biblioteca_Jogos
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

        [HttpPost("{id}")]

        public async Task<IActionResult> Post(ListaDto lista)
        {
            var email = User.FindFirst(ClaimTypes.Name)?.Value;
            
            var Usuario = await _Su.FirstOrDefault(email!);

            if (Usuario == null)
            {
                return NotFound();
            }

            await _Sl.PostSl(lista,email!);

            return Ok();




            

        }
    }
}
