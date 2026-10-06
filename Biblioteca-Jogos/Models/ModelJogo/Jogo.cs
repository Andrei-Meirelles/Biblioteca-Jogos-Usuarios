using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_Jogos
{
    public class Jogo
    {
        public int id { get; set; }
        public string Nome { get; set; } = string.Empty;

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
