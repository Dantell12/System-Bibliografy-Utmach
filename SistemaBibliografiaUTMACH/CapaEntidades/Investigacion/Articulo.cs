using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Inventario
{
    public class Articulo
    {
        private int idArticulo;
        private string titulo;
        private string palabrasclave;
        private string contacto;


        public Articulo(int idArticulo, string titulo, string palabrasclave, string contacto)
        {
            this.IdArticulo = idArticulo;
            this.Titulo = titulo;
            this.Palabrasclave = palabrasclave;
            this.Contacto = contacto;
        }

        public Articulo()
        {
          
        }
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Palabrasclave { get => palabrasclave; set => palabrasclave = value; }
        public string Contacto { get => contacto; set => contacto = value; }
    }
}
