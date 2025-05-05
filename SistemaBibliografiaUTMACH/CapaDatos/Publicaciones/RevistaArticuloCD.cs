using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Publicaciones
{
    public class RevistaArticuloCD
    {
        public static List<CP_ListarRevistaArticuloResult> ListarRevistaArticulo()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarRevistaArticulo().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Revista Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static List<CP_ListarV2RevistaArticuloResult> ListRevistaesArticulosV2()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarV2RevistaArticulo().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Revistas y Articulos", ex);
            }
            finally
            {
                DB = null;
            }
        }
        //Filtro
        public static List<CP_listarRevistaCientificaFiltroResult> ListarRevistaArticuloFiltro(string valor)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_listarRevistaCientificaFiltro(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar la lista de Revista Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Insertar
        public static void InsertarRevistaArticulo(CapaEntidades.Publicaciones.RevistaArticulo op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_InsertRevistaArticulo(op.Idrevista, op.Idarticulo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar insertar Revista Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }



        //modificar
        public static void ModificarRevistaArticulo(CapaEntidades.Publicaciones.RevistaArticulo op, int auxrev)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_ActualizarRevistaArticulo(op.Idrevista, op.Idarticulo, auxrev);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Revista Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Eliminar
        public static void EliminarRevistaArticulo(CapaEntidades.Publicaciones.RevistaArticulo op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_EliminarRevistaArticulo(op.Idrevista, op.Idarticulo);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Revista Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
