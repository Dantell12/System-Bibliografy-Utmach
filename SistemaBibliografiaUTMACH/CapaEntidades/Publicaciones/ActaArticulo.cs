using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Publicaciones
{
    public class ActaArticulo
    {
        private int idactacongreso;
        private int idarticulo;
        private string titulo;
        private string nombrecongreso;
        private string edicion;
        private string frecuencia;

        public ActaArticulo()
        {

        }
        public ActaArticulo(int idactacongreso, int idarticulo)
        {
            this.idactacongreso = idactacongreso;
            this.idarticulo = idarticulo;
        }

        public int Idactacongreso { get => idactacongreso; set => idactacongreso = value; }
        public int Idarticulo { get => idarticulo; set => idarticulo = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Nombrecongreso { get => nombrecongreso; set => nombrecongreso = value; }
        public string Edicion { get => edicion; set => edicion = value; }
        public string Frecuencia { get => frecuencia; set => frecuencia = value; }
    }
}
