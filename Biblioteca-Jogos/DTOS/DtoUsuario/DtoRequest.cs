using System.ComponentModel.DataAnnotations;
namespace Biblioteca_Usuario
{
    public class DtoRequest
    {

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(5)]
        
        public string Senha { get; set; } = string.Empty;
    }
}
