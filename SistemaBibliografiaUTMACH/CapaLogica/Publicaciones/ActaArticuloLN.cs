using CapaDatos.Publicaciones;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActaArticulo = CapaEntidades.Publicaciones.ActaArticulo;


namespace CapaLogica.Publicaciones
{
    public class ActaArticuloLN
    {
        public List<ActaArticulo> ViewActaArticulo()
        {
            List<ActaArticulo> ListaActaArticulo = new List<ActaArticulo>();
            ActaArticulo obp = null;
            try
            {
                List<CP_ListarActaArticuloResult> auxLista = ActaArticuloCD.ListarActaArticulo();
                foreach (CP_ListarActaArticuloResult op in auxLista)
                {
                    obp = new ActaArticulo(op.id_actacongreso, op.id_articulo);
                    ListaActaArticulo.Add(obp);
                }
                return ListaActaArticulo;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al logica Informe articulo");
            }
        }
        public List<ActaArticulo> ViewV2ActaArticulo()
        {
            List<ActaArticulo> list = new List<ActaArticulo>();
            ActaArticulo obp = null;
            try
            {
                List<CP_ListarV2ActaArticuloResult> auxLista = ActaArticuloCD.ListActaesArticulosV2();
                foreach (CP_ListarV2ActaArticuloResult op in auxLista)
                {
                    obp = new ActaArticulo();
                    obp.Idactacongreso = op.id_actacongreso;
                    obp.Idarticulo = op.id_articulo;
                    obp.Titulo = op.Titulo;
                    obp.Nombrecongreso = op.NombreCongreso;
                    obp.Edicion = op.Edicion;
                    obp.Frecuencia = op.Frecuencia;
                    list.Add(obp);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al logica Informe articulo");
            }
        }


        //insertar -> capaLogica
        public bool CreateActaArticulo(ActaArticulo op)
        {
            try
            {
                ActaArticuloCD.InsertarActaArticulo(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear Informe articulo", ex);
            }
        }
        //actualizar -> capaLogica
        public bool UpdateActaArticulo(ActaArticulo op, int auxact)
        {
            try
            {
                ActaArticuloCD.ModificarActaArticulo(op, auxact);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar Informe articulo", ex);
            }
        }
        //eliminar -> capaLogica
        public bool DeleteActaArticulo(ActaArticulo op)
        {
            try
            {
                ActaArticuloCD.EliminarActaArticulo(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar Informe articulo", ex);
            }
        }
    }
}
