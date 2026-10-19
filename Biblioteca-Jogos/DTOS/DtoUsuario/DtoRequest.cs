using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
namespace Biblioteca_Usuario
{
    public class DtoRequest
    {

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DefaultValue("")]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [DefaultValue("")]

        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(5)]
        [DefaultValue("")]
        
        public string Senha { get; set; } = string.Empty;
    }
}
