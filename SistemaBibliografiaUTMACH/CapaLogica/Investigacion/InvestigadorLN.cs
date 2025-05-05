
using CapaDatos;
using Investigador = CapaEntidades.Investigacion.Investigador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Investigacion;
using CapaDatos.Inventario;

namespace CapaLogica.Investigacion
{
    public class InvestigadorLN
    {
        public List<Investigador> ViewInvestigador()
        {
            List<Investigador> ListaInvestigador = new List<Investigador>();
            Investigador obp = null;
            try
            {
                List<CP_ListarInvestigadorResult> auxLista = InvestigadorCD.ListarInvestigador();
                foreach (CP_ListarInvestigadorResult op in auxLista)
                {
                    obp = new Investigador(op.id_investigador, op.Nombre, op.CentroTrabajo, op.Correo, op.Temas);
                    ListaInvestigador.Add(obp);
                }
                return ListaInvestigador;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error en la logica Investigador");
            }
        }
        public List<Investigador> ViewInvestigadorFiltro(string valor)
        {
            List<Investigador> ListaInvestigador = new List<Investigador>();
            Investigador obp = null;
            try
            {
                List<CP_ListarInvestigadorFiltroResult> auxLista = InvestigadorCD.ListarInvestigadorFiltro(valor);
                foreach (CP_ListarInvestigadorFiltroResult op in auxLista)
                {
                    obp = new Investigador(op.id_investigador, op.Nombre, op.CentroTrabajo, op.Correo, op.Temas);
                    ListaInvestigador.Add(obp);
                }
                return ListaInvestigador;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error en al logica Investigador");
            }
        }

        //insertar -> capaLogica
        public bool CreateInvestigador(Investigador op)
        {
            try
            {
                InvestigadorCD.InsertarInvestigador(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear Investigador", ex);
            }
        }
        //actualizar -> capaLogica
        public bool UpdateInvestigador(Investigador op)
        {
            try
            {
                InvestigadorCD.ModificarInvestigador(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar Investigador", ex);
            }
        }
        //eliminar -> capaLogica
        public bool DeleteInvestigador(Investigador op)
        {
            try
            {
                InvestigadorCD.EliminarInvestigador(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar Investigador", ex);
            }
        }
        public int createID()
        {
            int id = 0;
            int n = 1;
            List<CP_ListarInvestigadorResult> auxLista = InvestigadorCD.ListarInvestigador();
            foreach (CP_ListarInvestigadorResult op in auxLista)
            {
                if (op.id_investigador == n)
                {
                    n++;
                }
                else
                {
                    id = n;
                    break;
                }
            }

            if (id == 0)
            {
                id = n;
            }
            return id;
        }

    }
}
