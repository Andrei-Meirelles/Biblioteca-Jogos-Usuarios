using Microsoft.EntityFrameworkCore;
namespace Biblioteca_Usuario
{
    public class RepositoryUsuario
    {

        private readonly MyContext _context;
        public RepositoryUsuario(MyContext context)
        {
            _context = context;
        }

    

        public async Task<List<Usuario>> GetRU()
        {
            return await _context.Usuario.ToListAsync();

        }
        public async Task<bool> AnyAsync(string Email)
        {
            return await _context.Usuario.AnyAsync(n => n.Email == Email);

        }

        public async Task<Usuario?> FirsOrDefault(string Email)
        {
            return await _context.Usuario.FirstOrDefaultAsync(e => e.Email == Email);

        }

        public async Task PostRU(Usuario usuario)
        {
                _context.Add(usuario);

            await _context.SaveChangesAsync();


        }

       
         public async Task PutRU()
        {

            await _context.SaveChangesAsync();

        }

        public async Task DeleteRU(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<Usuario?> GetIdRU(int id)
        {
            return await _context.Usuario.FindAsync(id);

        }
       
    }
}
