using CapaEntidades.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Investigacion
{
    public class Investigador 
    {
        private int id_investigador;
        private string nombre;
        private string centrotrabajo;
        private string correo;
        private string temas;

        public Investigador(int id_investigador, string nombre, string centrotrabajo, string correo, string temas)
        {
            this.id_investigador = id_investigador;
            this.nombre = nombre;
            this.centrotrabajo = centrotrabajo;
            this.correo = correo;
            this.temas = temas;
        }
        public Investigador() { }

        public int Id_investigador { get => id_investigador; set => id_investigador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Centrotrabajo { get => centrotrabajo; set => centrotrabajo = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Temas { get => temas; set => temas = value; }
    }
}
