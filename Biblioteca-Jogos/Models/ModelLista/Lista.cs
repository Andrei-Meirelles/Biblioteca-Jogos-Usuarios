using Biblioteca_Jogos;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_Usuario
{
    public class Lista
    {
        public Lista()
        {

        }
        public int idUsuario { get; set; }
        public int idJogo { get; set; }

        
        public Lista(int idusuario, int idjogo)
        {

            idUsuario = idusuario;
                idJogo = idjogo;
        }

       
    }
}
