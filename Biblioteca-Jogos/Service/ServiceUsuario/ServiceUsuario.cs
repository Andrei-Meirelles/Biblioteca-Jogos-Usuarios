using Biblioteca_Usuario;

namespace Biblioteca_Usuario
{
    public class ServiceUsuario
    {
        private readonly RepositoryUsuario _Ru;

        public ServiceUsuario(RepositoryUsuario Ru)
        {
            _Ru = Ru;
        }

        public async Task<List<DtoResponse>?> GetSU()
        {
            var Usuarios = await _Ru.GetRU();
            if (Usuarios.Count == 0)
            {
                return null;
            }
            return Usuarios.Select(u => new DtoResponse
            {
                id = u.id,
                Nome = u.Nome
              

            }).ToList();

            
            
          
        }
        public async Task<Usuario?> PostSU(DtoRequest requestdto)
        {

             if (requestdto == null)
            {
                return null;
            }

            var usuarionovo = new Usuario(requestdto.Nome, requestdto.Email, requestdto.Senha);

            await _Ru.PostRU(usuarionovo);

            return usuarionovo;
            


        }
        public async Task<DtoResponse?> PutSU(int id)
        {
            var usuario = await _Ru.GetIdRU(id);
            if (usuario == null)
            {
                return null;
            }

            var responsedto = new DtoResponse()
            {
                id = usuario.id,
                Nome = usuario.Nome


            };
            return responsedto;



        }


        public async Task<bool> DeleteSU(int id)
        {
            var usuario = await _Ru.GetIdRU(id);
            if (usuario == null)
            {
                return false;
            }
            await _Ru.DeleteRU(usuario);

            return true;

        }
        

    }
}
