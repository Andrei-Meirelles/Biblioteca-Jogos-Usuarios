using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_Jogos
{ 
    public class JogoRequest
    {
        [Required]
        [DefaultValue("")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome do jogo deve ter entre 2 e 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [DefaultValue(0)]
        [Range(0, 10, ErrorMessage = "A avaliação deve estar entre 0 e 10.")]
        public decimal Avaliacao { get; set; }

        [Required]
        [DefaultValue("Jogando")]
        [EnumDataType(typeof(StatusJogo), ErrorMessage = "O status do jogo deve ser 'Jogando', 'Desejando' ou 'Finalizado'.")]

        public StatusJogo Status { get; set; }
    }
}
