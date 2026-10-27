using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_Usuario
{
    public class LoginDto
    {
        [Required]
        [DefaultValue("")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DefaultValue("")]
        public string Senha { get; set; } = string.Empty;
    }
}
