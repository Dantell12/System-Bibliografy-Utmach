using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Inventario
{
    public class ArticuloCD
    {
        public static List<CP_ListarArticuloResult> ListarArticulo()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarArticulo().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Investigador", ex);
            }
            finally
            {
                DB = null;
            }
        }
        //Filtro
        public static List<CP_listararticulosFiltroResult> ListarArticuloFiltro(string valor)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_listararticulosFiltro(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar la lista de Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Insertar
        public static void InsertarArticulo(CapaEntidades.Inventario.Articulo op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_InsertarArticulo(op.IdArticulo, op.Titulo, op.Palabrasclave, op.Contacto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar insertar Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }



        //modificar
        public static void ModificarArticulo(CapaEntidades.Inventario.Articulo op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_ActualizarArticulo(op.IdArticulo, op.Titulo, op.Palabrasclave, op.Contacto);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Eliminar
        public static void EliminarArticulo(CapaEntidades.Inventario.Articulo op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_EliminarArticulo(op.IdArticulo);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
