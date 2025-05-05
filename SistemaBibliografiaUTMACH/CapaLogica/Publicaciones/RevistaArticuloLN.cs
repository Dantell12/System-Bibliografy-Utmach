using CapaDatos.Investigacion;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevistaArticulo = CapaEntidades.Publicaciones.RevistaArticulo;
using CapaDatos.Publicaciones;

namespace CapaLogica.Publicaciones
{
    public class RevistaArticuloLN
    {
        public List<RevistaArticulo> ViewRevistaArticulo()
        {
            List<RevistaArticulo> ListaRevistaArticulo = new List<RevistaArticulo>();
            RevistaArticulo obp = null;
            try
            {
                List<CP_ListarRevistaArticuloResult> auxLista = RevistaArticuloCD.ListarRevistaArticulo();
                foreach (CP_ListarRevistaArticuloResult op in auxLista)
                {
                    obp = new RevistaArticulo((int)op.IdRevista, (int) op.IdArticulo);
                    ListaRevistaArticulo.Add(obp);
                }
                return ListaRevistaArticulo;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al logica Revista articulo");
            }
        }
        public List<RevistaArticulo> ViewV2RevistaesArticulos()
        {
            List<RevistaArticulo> list = new List<RevistaArticulo>();
            RevistaArticulo obp = null;
            try
            {
                List<CP_ListarV2RevistaArticuloResult> auxLista = RevistaArticuloCD.ListRevistaesArticulosV2();
                foreach (CP_ListarV2RevistaArticuloResult op in auxLista)
                {
                    obp = new RevistaArticulo();
                    obp.Idrevista = op.id_revista;
                    obp.Idarticulo = op.id_articulo;
                    obp.Titulo = op.Titulo;
                    obp.Nombrerevista = op.Nombre;
                    obp.Editor = op.Editor;
                    obp.Costo = op.Costo;
                    list.Add(obp);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al logica Revista articulo");
            }
        }
     

        //insertar -> capaLogica
        public bool CreateRevistaArticulo(RevistaArticulo op)
        {
            try
            {
                RevistaArticuloCD.InsertarRevistaArticulo(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear Revista articulo", ex);
            }
        }
        //actualizar -> capaLogica
        public bool UpdateRevistaArticulo(RevistaArticulo op, int auxrev)
        {
            try
            {
                RevistaArticuloCD.ModificarRevistaArticulo(op, auxrev);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar Revista articulo", ex);
            }
        }
        //eliminar -> capaLogica
        public bool DeleteRevistaArticulo(RevistaArticulo op)
        {
            try
            {
                RevistaArticuloCD.EliminarRevistaArticulo(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar Revista articulo", ex);
            }
        }
    }
}
