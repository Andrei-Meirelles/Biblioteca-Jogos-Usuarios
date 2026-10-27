using Biblioteca_Jogos;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Usuario
{
    public class RepositoryLista
    {
        private readonly MyContext _context;

        public RepositoryLista(MyContext context)
        {
            _context = context;
        }

        public async Task<List<int>?> getRL(Usuario usuario)
        {
            return await _context.Lista.Where(x => x.idUsuario == usuario.id).Select(x => x.idJogo).ToListAsync();
        }
        public async Task PostRl(Lista lista)
        {
            _context.Lista.Add(lista);

            await _context.SaveChangesAsync();


        }
            public async Task<List<Jogo>?> getRj(List<int> ids)
        {
            return await _context.Jogo.Where(x => ids.Contains(x.id)).ToListAsync();
        }

    }
}
