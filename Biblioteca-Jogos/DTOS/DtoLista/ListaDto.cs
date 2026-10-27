using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_Jogos.DTOS.DtoLista
{
    public class ListaDto
    {
        [Required]
        [DefaultValue(0)]
        public int idJogo { get; set; }
    }
}
