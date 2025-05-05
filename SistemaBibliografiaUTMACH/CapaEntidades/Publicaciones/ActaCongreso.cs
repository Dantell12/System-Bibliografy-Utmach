using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Publicaciones
{
    public class ActaCongreso
    {
        private int id_ActaCongreso;
        private string nombreCongreso;
        private string edicion;
        private string ciudadCelebracion;
        private DateTime fechainicio;
        private DateTime fechafinalizacion;
        private string TipoCongreso;
        private string pais;
        private string añoprimera;
        private string frecuencia;

        public ActaCongreso(int id_ActaCongreso, string nombreCongreso, string edicion, string ciudadCelebracion, DateTime fechainicio, DateTime fechafinalizacion, string tipoCongreso, string pais, string añoprimera, string frecuencia)
        {
            this.id_ActaCongreso = id_ActaCongreso;
            this.nombreCongreso = nombreCongreso;
            this.edicion = edicion;
            this.ciudadCelebracion = ciudadCelebracion;
            this.fechainicio = fechainicio;
            this.fechafinalizacion = fechafinalizacion;
            TipoCongreso = tipoCongreso;
            this.pais = pais;
            this.añoprimera = añoprimera;
            this.frecuencia = frecuencia;
        }

        public int Id_ActaCongreso { get => id_ActaCongreso; set => id_ActaCongreso = value; }
        public string NombreCongreso { get => nombreCongreso; set => nombreCongreso = value; }
        public string Edicion { get => edicion; set => edicion = value; }
        public string CiudadCelebracion { get => ciudadCelebracion; set => ciudadCelebracion = value; }
        public DateTime Fechainicio { get => fechainicio; set => fechainicio = value; }
        public DateTime Fechafinalizacion { get => fechafinalizacion; set => fechafinalizacion = value; }
        public string TipoCongreso1 { get => TipoCongreso; set => TipoCongreso = value; }
        public string Pais { get => pais; set => pais = value; }
        public string Añoprimera { get => añoprimera; set => añoprimera = value; }
        public string Frecuencia { get => frecuencia; set => frecuencia = value; }
    }
}
