using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Investigacion
{
    public class InvestigadorCD
    {
        public static List<CP_ListarInvestigadorResult> ListarInvestigador()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarInvestigador().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Investsigador", ex);
            }
            finally
            {
                DB = null;
            }
        }
        //Filtro
        public static List<CP_ListarInvestigadorFiltroResult> ListarInvestigadorFiltro(string valor)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarInvestigadorFiltro(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar la lista de Investigador", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Insertar
        public static void InsertarInvestigador(CapaEntidades.Investigacion.Investigador op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_InsertarInvestigador(op.Id_investigador, op.Nombre, op.Centrotrabajo, op.Correo, op.Temas);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar insertar Investigador", ex);
            }
            finally
            {
                DB = null;
            }
        }



        //modificar
        public static void ModificarInvestigador(CapaEntidades.Investigacion.Investigador op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_ActualizarInvestigador(op.Id_investigador, op.Nombre, op.Centrotrabajo, op.Correo, op.Temas);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Investigador", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Eliminar
        public static void EliminarInvestigador(CapaEntidades.Investigacion.Investigador op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.Cp_EliminarInvestigador(op.Id_investigador);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Investigador", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
