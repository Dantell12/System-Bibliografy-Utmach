using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Publicaciones
{
    public class RevistaArticulo
    {
        private int idrevista;
        private int idarticulo;
        private string titulo;
        private string nombrerevista;
        private string editor;
        private decimal? costo;

        public RevistaArticulo()
        {

        }
        public RevistaArticulo(int idrevista, int idarticulo)
        {
            this.idrevista = idrevista;
            this.idarticulo = idarticulo;
        }
        public int Idarticulo { get => idarticulo; set => idarticulo = value; }
        public int Idrevista { get => idrevista; set => idrevista = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Nombrerevista { get => nombrerevista; set => nombrerevista = value; }
        public string Editor { get => editor; set => editor = value; }
        public decimal? Costo { get => costo; set => costo = value; }
    }
}
