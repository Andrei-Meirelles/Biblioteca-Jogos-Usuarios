namespace Biblioteca_Jogos
{ 
    public class JogoRequest
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Avaliacao { get; set; }

        public StatusJogo Status { get; set; }
    }
}
