using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_Jogos
{
    public class Jogo
    {
        public int id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]

        [Column(TypeName = "decimal(4,2)")]
        public decimal Avaliacao { get; set; }
        public StatusJogo Status{ get; set; }

        public Jogo (string nome, decimal avaliacao, StatusJogo status)
        {
            Nome = nome;
            Avaliacao = avaliacao;
            Status = status;
        }

    }
}
