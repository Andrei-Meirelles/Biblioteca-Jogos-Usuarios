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

        public async Task<List<Lista>?> getRL()
        {
            return await _context.Lista.ToListAsync();
        }
        public async Task PostRl(Lista lista)
        {
            _context.Lista.Add(lista);

           await _context.SaveChangesAsync();
        }
    }
}
