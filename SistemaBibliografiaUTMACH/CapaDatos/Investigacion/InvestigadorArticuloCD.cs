using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Investigacion
{
    public class InvestigadorArticuloCD
    {
        public static List<CP_ListarInvestigador_ArticuloResult> ListarInvestigadorArticulo()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarInvestigador_Articulo().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Investigador Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static List<CP_ListarInvestigadores_ArticulosResult> ListInvestigadoresArticulos()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarInvestigadores_Articulos().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Investigadores y Articulos", ex);
            }
            finally
            {
                DB = null;
            }
        }
        //Filtro
        public static List<CP_ListarInvestigador_ArticuloFiltroResult> ListarInvestigadorArticuloFiltro(string valor)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarInvestigador_ArticuloFiltro(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar la lista de Investigador Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Insertar
        public static void InsertarInvestigadorArticulo(CapaEntidades.Investigacion.InvestigadorArticulo op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_InsertarInvestigador_Articulo(op.IdInvestigador, op.IdArticulo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar insertar Investigador Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }



        //modificar
        public static void ModificarInvestigadorArticulo(CapaEntidades.Investigacion.InvestigadorArticulo op, int aux_inv)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_ActualizarInvestigadorArticulo(op.IdInvestigador, op.IdArticulo, aux_inv );
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Investigador Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Eliminar
        public static void EliminarInvestigadorArticulo(CapaEntidades.Investigacion.InvestigadorArticulo op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_EliminarInvestigadorArticulo(op.IdArticulo, op.IdInvestigador);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Investigador Articulo", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}

