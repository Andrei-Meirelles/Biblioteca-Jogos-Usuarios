using Microsoft.EntityFrameworkCore;
using Biblioteca_Jogos;


namespace Biblioteca_Usuario
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base (options)
        {




        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Jogo> Jogo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogo>().Property(j => j.Status).HasConversion<string>();
               }
    }
}
