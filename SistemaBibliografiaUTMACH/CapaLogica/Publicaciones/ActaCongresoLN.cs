using CapaDatos;
using CapaDatos.Inventario;
using CapaDatos.Publicaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActaCongreso = CapaEntidades.Publicaciones.ActaCongreso;

namespace CapaLogica.Publicaciones
{
    public class ActaCongresoLN
    {
        public List<ActaCongreso> ViewActaCongreso()
        {
            List<ActaCongreso> ListaActaCongreso = new List<ActaCongreso>();
            ActaCongreso obp = null;
            try
            {
                List<CP_ListarActaCongresoResult> auxLista = ActaCongresoCD.ListarActaCongreso();
                foreach (CP_ListarActaCongresoResult op in auxLista)
                {
                    obp = new ActaCongreso(op.id_actacongreso, op.NombreCongreso, op.Edicion, op.CiudadCelebracion, (DateTime)op.FechaInicio, (DateTime)op.FechaFinalizacion, op.TipoCongreso, op.Pais, op.AñoPrimeraCelebracion, op.Frecuencia);
                    ListaActaCongreso.Add(obp);
                }
                return ListaActaCongreso;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error en la logica ActaCongreso");
            }
        }
        public List<ActaCongreso> ViewActaCongresoFiltro(string valor)
        {
            List<ActaCongreso> ListaActaCongreso = new List<ActaCongreso>();
            ActaCongreso obp = null;
            try
            {
                List<CP_listaractaCongresoFiltroResult> auxLista = ActaCongresoCD.ListarActaCongresoFiltro(valor);
                foreach (CP_listaractaCongresoFiltroResult op in auxLista)
                {
                    obp = new ActaCongreso(op.id_actacongreso, op.NombreCongreso, op.Edicion, op.CiudadCelebracion, (DateTime)op.FechaInicio, (DateTime)op.FechaFinalizacion, op.TipoCongreso, op.Pais, op.AñoPrimeraCelebracion, op.Frecuencia);
                    ListaActaCongreso.Add(obp);
                }
                return ListaActaCongreso;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error en la logica Acta Congreso");
            }
        }

        //insertar -> capaLogica
        public bool CreateActaCongreso(ActaCongreso op)
        {
            try
            {
                ActaCongresoCD.InsertarActaCongreso(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear Acta de Congreso", ex);
            }
        }
        //actualizar -> capaLogica
        public bool UpdateActaCongreso(ActaCongreso op)
        {
            try
            {
                ActaCongresoCD.ModificarActaCongreso(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar Acta de Congreso", ex);
            }
        }
        //eliminar -> capaLogica
        public bool DeleteActaCongreso(ActaCongreso op)
        {
            try
            {
                ActaCongresoCD.EliminarActaCongreso(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar Acta de Congreso", ex);
            }
        }
        public int createID()
        {
            int id = 0;
            int n = 1;
            List<CP_ListarActaCongresoResult> auxLista = ActaCongresoCD.ListarActaCongreso();
            foreach (CP_ListarActaCongresoResult op in auxLista)
            {
                if (op.id_actacongreso == n)
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
