using Biblioteca_Jogos;
using Biblioteca_Usuario;
using Microsoft.EntityFrameworkCore;
namespace Biblioteca_Jogos
{
    public class RepositoryJogo
    {
        private readonly MyContext _context;

        public RepositoryJogo(MyContext context)
        {
            _context = context;
        }


        public async Task<List<Jogo>> GetRJ()
        {
            return await _context.Jogo.ToListAsync();
        }
        public async Task PostRj(Jogo jogo)
        {
            _context.Jogo.Add(jogo);
            await _context.SaveChangesAsync();


        }
        public async Task PutRj()
        {
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRJ(Jogo jogo)
        {
            _context.Jogo.Remove(jogo);
            await _context.SaveChangesAsync();

        }

        public async Task<Jogo?> GetIdRJ(int id)
        {
            return await _context.Jogo.FindAsync(id);
        }
    }
}
