using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Publicaciones
{
    public class RevistaCientifica
    {
        private int? id_revista;
        private string nombre;
        private string editor;
        private DateTime? añopublicacion;
        private string frecuencia;
        private string temas;
        private int? numero;
        private DateTime? añopublicacionActual;
        private decimal? costo;

        public RevistaCientifica(int? id_revista, string nombre, string editor, DateTime? añopublicacion, string frecuencia, string temas, int? numero, DateTime? añopublicacionActual, decimal? costo)
        {
            this.id_revista = id_revista;
            this.nombre = nombre;
            this.editor = editor;
            this.añopublicacion = añopublicacion;
            this.frecuencia = frecuencia;
            this.temas = temas;
            this.numero = numero;
            this.añopublicacionActual = añopublicacionActual;
            this.costo = costo;
        }

        public int? Id_revista { get => id_revista; set => id_revista = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Editor { get => editor; set => editor = value; }
        public DateTime? Añopublicacion { get => añopublicacion; set => añopublicacion = value; }
        public string Frecuencia { get => frecuencia; set => frecuencia = value; }
        public string Temas { get => temas; set => temas = value; }
        public int? Numero { get => numero; set => numero = value; }
        public DateTime? AñopublicacionActual { get => añopublicacionActual; set => añopublicacionActual = value; }
        public decimal? Costo { get => costo; set => costo = value; }
    }
}
