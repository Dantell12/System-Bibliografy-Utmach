using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Publicaciones
{
    public class InformeArticulo
    {
        private int idinforme;
        private int idarticulo;
        private string titulo;
        private string numeroinforme;
        private string centropublicacion;

        public InformeArticulo()
        {

        }
        public InformeArticulo(int idinforme, int idarticulo)
        {
            this.idinforme = idinforme;
            this.idarticulo = idarticulo;
        }

        public int Idinforme { get => idinforme; set => idinforme = value; }
        public int Idarticulo { get => idarticulo; set => idarticulo = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Numeroinforme { get => numeroinforme; set => numeroinforme = value; }
        public string Centropublicacion { get => centropublicacion; set => centropublicacion = value; }
    }
}
