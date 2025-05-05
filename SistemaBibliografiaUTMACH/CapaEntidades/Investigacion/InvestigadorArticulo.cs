using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Investigacion
{
    public class InvestigadorArticulo
    {
        private int idInvestigador;
        private int idArticulo;
        private string titulo;
        private string nombre;

        public InvestigadorArticulo(int idInvestigador, int idArticulo)
        {
            this.idInvestigador = idInvestigador;
            this.idArticulo = idArticulo;
        }
        public InvestigadorArticulo()
        {

        }
        public int IdInvestigador { get => idInvestigador; set => idInvestigador = value; }
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
