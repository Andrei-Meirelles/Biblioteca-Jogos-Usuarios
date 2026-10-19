using Biblioteca_Jogos;
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

        public async Task<List<Lista>?> GetSL()
        {
            return await _Rl.getRL();
        }

        public async Task<bool> PostSl(ListaDto lista,string Email)
        {
            if (lista == null)
            {
                return false;
            }
            var usuario = await _Ru.FirsOrDefault(Email);
            var jogo = await _Rj.GetIdRJ(lista.idJogo);

            var jogolista = new Lista(jogo!.id, usuario!.id);

            await _Rl.PostRl(jogolista);

            return true;
        }
    }
}
