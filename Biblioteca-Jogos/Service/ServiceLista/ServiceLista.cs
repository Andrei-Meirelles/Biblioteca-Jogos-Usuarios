using Biblioteca_Jogos;
using Biblioteca_Jogos.DTOS.DtoJogo;
using Biblioteca_Jogos.DTOS.DtoLista;

namespace Biblioteca_Usuario
{
    public class ServiceLista
    {
        private readonly RepositoryLista _Rl;
        private readonly RepositoryJogo _Rj;

        private readonly RepositoryUsuario _Ru;


        public ServiceLista(RepositoryLista Rl, RepositoryJogo Rj,RepositoryUsuario Ru)
        {
            _Rl = Rl;
            _Rj = Rj;
            _Ru = Ru;
        }

        public async Task<List<JogoResponse>?> GetSL(string Email)
        {
           
            if (Email == null)
            {
                return null;
            }
            var usuario = await _Ru.FirsOrDefault(Email);
            var lista = await _Rl.getRL(usuario!);

            
            var jogos = await _Rl.getRj(lista!);

            if (usuario == null ||lista == null)
            {
                return null;
            }

            return jogos!.Select(j => new JogoResponse
            {

                Nome = j.Nome,
                Avaliacao = j.Avaliacao,
                Status = j.Status


            }).ToList();

            
        }

        public async Task<bool> PostSl(ListaDto lista,string Email)
        {
            if (lista == null || Email == null)
            {
                return false;
            }
            var usuario = await _Ru.FirsOrDefault(Email);

            var jogo = await _Rj.GetIdRJ(lista.idJogo);

            if (usuario == null || jogo == null)
            {
                return false;
            }

            var jogolista = new Lista(usuario!.id, jogo!.id);

            await _Rl.PostRl(jogolista);

            return true;
        }
    }
}
