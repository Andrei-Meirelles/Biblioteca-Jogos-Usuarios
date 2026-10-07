namespace Biblioteca_Jogos
{
    public class ServiceJogo
    {

        private readonly RepositoryJogo _Rj;

        public ServiceJogo(RepositoryJogo Rj)
        {
            _Rj = Rj;
        }

        public async Task<List<Jogo>?> GetSJ()
        {
            var jogo = await _Rj.GetRJ();
            if (jogo.Count == 0)
            {
                return null;
            }
            return jogo;



        }

        public async Task<Jogo?> PostSJ(JogoRequest jogodto)
        {
            if (jogodto == null)
            {
                return null;
            }
            var jogonovo = new Jogo(jogodto.Nome, jogodto.Avaliacao, jogodto.Status);

            await _Rj.PostRj(jogonovo);

            return jogonovo;

        }

        public async Task<Jogo?> PutSJ(int id)
        {
            var jogo = await _Rj.GetIdRJ(id);
            if (jogo == null)
            {
                return null;
            }
            await _Rj.PutRj();

            return jogo;

        }

        public async Task<bool> DeleteSJ(int id)
        {
            var jogo = await _Rj.GetIdRJ(id);
            if(jogo == null)
            {
                return false;
            }
            await _Rj.DeleteRJ(jogo);

            return true;

        }
    }
}
