using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Publicaciones
{
    public class ActaArticuloCD
    {
        public static List<CP_ListarActaArticuloResult> ListarActaArticulo()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarActaArticulo().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Acta Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static List<CP_ListarV2ActaArticuloResult> ListActaesArticulosV2()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarV2ActaArticulo().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Actas y Articulos", ex);
            }
            finally
            {
                DB = null;
            }
        }
        //Filtro
        public static List<CP_ListarActaArticuloFiltroResult> ListarActaArticuloFiltro(string valor)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarActaArticuloFiltro(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar la lista de Acta Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Insertar
        public static void InsertarActaArticulo(CapaEntidades.Publicaciones.ActaArticulo op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_InsertarActaArticulo(op.Idactacongreso, op.Idarticulo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar insertar Acta Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }



        //modificar
        public static void ModificarActaArticulo(CapaEntidades.Publicaciones.ActaArticulo op, int auxact)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_ActualizarActaArticulo(op.Idactacongreso, op.Idarticulo, auxact);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Acta Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Eliminar
        public static void EliminarActaArticulo(CapaEntidades.Publicaciones.ActaArticulo op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_EliminarActaArticulo(op.Idactacongreso, op.Idarticulo);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Acta Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
