using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
namespace Biblioteca_Usuario
{
    public class DtoRequest
    {

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 a 100 caracteres.")]
        [DefaultValue("")]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [DefaultValue("")]

        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "A senha deve ter entre 5 e 100 caracteres.")]
        [DefaultValue("")]
        
        public string Senha { get; set; } = string.Empty;
    }
}
