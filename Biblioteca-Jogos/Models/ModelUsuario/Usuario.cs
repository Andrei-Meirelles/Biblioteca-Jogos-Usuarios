using System.ComponentModel.DataAnnotations;

namespace Biblioteca_Usuario

{
    public class Usuario
    {
        public int id { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; } 
        public string Cargo { get; private set; } = "Usuario";

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
