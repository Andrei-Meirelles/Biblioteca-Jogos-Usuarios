namespace Biblioteca_Jogos.DTOS.DtoJogo
{
    public class JogoResponse
    {

        public string Nome { get; set; } = string.Empty;

        public decimal Avaliacao { get; set; }
        public StatusJogo Status { get; set; }
    }
}
