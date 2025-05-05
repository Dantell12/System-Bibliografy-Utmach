using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Publicaciones
{
    public class InformeArticuloCD
    {
        public static List<CP_ListarInformeArticuloResult> ListarInformeArticulo()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarInformeArticulo().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Informe Técnico Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static List<CP_ListarV2InformeArticuloResult> ListInformeArticulosV2()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarV2InformeArticulo().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Informe Técnicos y Articulos", ex);
            }
            finally
            {
                DB = null;
            }
        }
        //Filtro
        public static List<CP_ListarInformeArticuloFiltroResult> ListarInformeArticuloFiltro(string valor)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarInformeArticuloFiltro(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar la lista de Informe Técnico Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Insertar
        public static void InsertarInformeArticulo(CapaEntidades.Publicaciones.InformeArticulo op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_InsertarInformeArticulo(op.Idinforme, op.Idarticulo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar insertar Informe Técnico Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }



        //modificar
        public static void ModificarInformeArticulo(CapaEntidades.Publicaciones.InformeArticulo op, int auxinf)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_ActualizarInformeArticulo(op.Idinforme, op.Idarticulo, auxinf);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Informe Técnico Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Eliminar
        public static void EliminarInformeArticulo(CapaEntidades.Publicaciones.InformeArticulo op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_EliminarInformeArticulo(op.Idinforme, op.Idarticulo);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Informe Técnico Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
