using CapaDatos;
using CapaDatos.Investigacion;
using CapaEntidades.Investigacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigadorArticulo = CapaEntidades.Investigacion.InvestigadorArticulo;
using System.Dynamic;

namespace CapaLogica.Investigacion
{
    public class InvestigadorArticuloLN
    {
        public List<InvestigadorArticulo> ViewInvestigadorArticulo()
        {
            List<InvestigadorArticulo> ListaInvestigadorArticulo = new List<InvestigadorArticulo>();
            InvestigadorArticulo obp = null;
            try
            {
                List<CP_ListarInvestigador_ArticuloResult> auxLista = InvestigadorArticuloCD.ListarInvestigadorArticulo();
                foreach (CP_ListarInvestigador_ArticuloResult op in auxLista)
                {
                    obp = new InvestigadorArticulo(op.id_investigador, op.id_articulo);
                    ListaInvestigadorArticulo.Add(obp);
                }
                return ListaInvestigadorArticulo;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al logica investigador articulo");
            }
        }
        public List<InvestigadorArticulo> ViewInvestigadoresArticulos()
        {
            List<InvestigadorArticulo> list = new List<InvestigadorArticulo> ();
            InvestigadorArticulo obp = null;
            try
            {
                List<CP_ListarInvestigadores_ArticulosResult> auxLista = InvestigadorArticuloCD.ListInvestigadoresArticulos();
                foreach (CP_ListarInvestigadores_ArticulosResult op in auxLista)
                {
                    obp = new InvestigadorArticulo();
                    obp.IdArticulo = op.id_articulo;
                    obp.IdInvestigador = op.id_investigador;
                    obp.Titulo = op.Titulo;
                    obp.Nombre = op.Nombre;
                    list.Add(obp);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al logica investigador articulo");
            }
        }
        public List<InvestigadorArticulo> ViewInvestigadorArticuloFiltro(string valor)
        {
            List<InvestigadorArticulo> ListaInvestigadorArticulo = new List<InvestigadorArticulo>();
            InvestigadorArticulo obp = null;
            try
            {
                List<CP_ListarInvestigador_ArticuloFiltroResult> auxLista = InvestigadorArticuloCD.ListarInvestigadorArticuloFiltro(valor);
                foreach (CP_ListarInvestigador_ArticuloFiltroResult op in auxLista)
                {
                    obp = new InvestigadorArticulo(op.id_investigador, op.id_articulo);
                    ListaInvestigadorArticulo.Add(obp);
                }
                return ListaInvestigadorArticulo;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al logica Investigador articulo");
            }
        }

        //insertar -> capaLogica
        public bool CreateInvestigadorArticulo(InvestigadorArticulo op)
        {
            try
            {
                InvestigadorArticuloCD.InsertarInvestigadorArticulo(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear investigador articulo", ex);
            }
        }
        //actualizar -> capaLogica
        public bool UpdateInvestigadorArticulo(InvestigadorArticulo op, int aux)
        {
            try
            {
                InvestigadorArticuloCD.ModificarInvestigadorArticulo(op, aux);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar Investigador articulo", ex);
            }
        }
        //eliminar -> capaLogica
        public bool DeleteInvestigadorArticulo(InvestigadorArticulo op)
        {
            try
            {
                InvestigadorArticuloCD.EliminarInvestigadorArticulo(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar Investigador articulo", ex);
            }
        }
        
    }
}
