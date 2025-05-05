using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Publicaciones
{
    public class InformeTecnico
    {
        private int id_Informe;
        private string numero;
        private string centropublicacion;
        private string mespublicacion;
        private string añopublicacion;

        public InformeTecnico(int id_Informe, string numero, string centropublicacion, string mespublicacion, string añopublicacion)
        {
            this.id_Informe = id_Informe;
            this.numero = numero;
            this.centropublicacion = centropublicacion;
            this.mespublicacion = mespublicacion;
            this.añopublicacion = añopublicacion;
        }

        public int Id_Informe { get => id_Informe; set => id_Informe = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Centropublicacion { get => centropublicacion; set => centropublicacion = value; }
        public string Mespublicacion { get => mespublicacion; set => mespublicacion = value; }
        public string Añopublicacion { get => añopublicacion; set => añopublicacion = value; }
    }
}
